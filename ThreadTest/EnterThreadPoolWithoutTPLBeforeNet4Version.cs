using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    /// <summary>
    /// For .Net version < 4.0, you must use one of the older constructs for entering the thread pool: ThreadPool.QueueUserWorkItem 
    /// or asynchronous delegates.
    /// The difference between the two is that asynchronous delegates let you return data from the thread.
    /// Asynchronous delegates also marshal any exception back to the caller.
    /// </summary>
    class EnterThreadPoolWithoutTPLBeforeNet4Version
    {
        #region ThreadPool.QueueUserWorkItem

        static void Main()
        {
            WaitCallback g = new WaitCallback(Go);
            ThreadPool.QueueUserWorkItem(g);
            ThreadPool.QueueUserWorkItem(Go, 123);
            Console.ReadLine();
        }

        static void Go(object data)   // data will be null with the first call.
        {
            Console.WriteLine("Hello from the thread pool! " + data);
        }

        #endregion

        #region Asynchronous Delegates

        /// <summary>
        /// Allows any no of arguments to be passed in both directions(mechanism for getting data from threads).
        /// Furthermore, unhandled exceptions on async delegates are conveniently rethrown on the original thread 
        /// (or more accurately, the thread that calls EndInvoke), and so they don’t need explicit handling.
        /// </summary>
        static void Main()
        {
            //Instantiate a delegate targeting the method you want to run in parallel (typically one of the predefined Func delegates).
            Func<string, int> method = GetLength;

            //Call BeginInvoke on the delegate, saving its IAsyncResult return value.
            //BeginInvoke returns immediately to the caller. You can then perform other activities while the pooled thread is working.
            IAsyncResult asynResult = method.BeginInvoke("test", null, null);

            //When you need the results, call EndInvoke on the delegate, passing in the saved IAsyncResult object.
            int length = method.EndInvoke(asynResult);

            //EndInvoke does 3 things:
            //1) First, it waits for the asynchronous delegate to finish executing, if it hasn’t already. 
            //2) Second, it receives the return value (as well as any ref or out parameters).
            //3) Third, it throws any unhandled worker exception back to the calling thread.
        }

        private static int GetLength(string inputStr)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
