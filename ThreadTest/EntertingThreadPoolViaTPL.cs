using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadTest
{
    /// <summary>
    /// Wait upon background threads when exiting an application. You could do it in 2 ways:
    /// 1) If you've created a thread yourself, call Join on the thread.
    /// 2) If you're on pooled thread, use an event wait handle.
    /// The above 2 things are done as backup exit strategy if thread refuses to finish( where you have to use tAsk Manager to kill the application).
    /// Number of ways to enter THREAD POOL:
    /// 1)Via the Task Parallel Library (from Framework 4.0)
    /// 2)By calling ThreadPool.QueueUserWorkItem
    /// 3)Via asynchronous delegates
    /// 4)Via BackgroundWorker
    /// </summary>
    class EntertingThreadPoolViaTPL
    {
        //To use the nongeneric Task class, call Task.Factory.StartNew, passing in a delegate of the target method.
        //This is a REPLACEMENT to ThreadPool.QueueWorkItem. NO RESULTS are returned, just action.
        #region Non-generic Task Class

        static void Main()    // The Task class is in System.Threading.Tasks
        {
            Task.Factory.StartNew(Go);
        }

        static void Go()
        {
            Console.WriteLine("Hello from the thread pool!");
        }

        //Task.Factory.StartNew returns a Task object, which you can then use to monitor the task — for instance, 
        //you can wait for it to complete by calling its Wait method. In the case of TP.QueueWorkItem, it doesn't return any object, you must explicity
        //deal with unhandled exceptions.

        #endregion

        #region Generic Task Class

        //The generic Task<TResult> class is a subclass of the non-generic Task. It lets you get a return value back from the task after it finishes executing.
        //Task<TResult> is a replacement to Async delegates.
        static void Main()
        {
            // Start the task executing:
            Task<string> task = Task.Factory.StartNew<string>
              (() => DownloadString("http://www.linqpad.net"));

            // We can do other work here and it will execute in parallel:
            RunSomeOtherMethod();

            // When we need the task's return value, we query its Result property:
            // If it's still executing, the current thread will now block (wait)
            // until the task finishes:
            string result = task.Result;

            //If you fail to query its Result proeprty or dont call WAIT, any unhandled exception will take down the process.
        }

        private static void RunSomeOtherMethod()
        {
            Console.WriteLine("Some other mehtod executing parallely");   
        }

        static string DownloadString(string uri)
        {
            using (var wc = new System.Net.WebClient())
                return wc.DownloadString(uri);
        }

        #endregion
    }
}
