using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    /// <summary>
    /// Any try/catch/finally blocks in scope when a thread is created are of no relevance to the thread when it starts executing.
    /// </summary>
    class ExceptionHandlingWithThreads
    {
        #region Wrong way of applying try/catch/finally in threading.

        public static void Main()
        {
            try
            {
                new Thread(Go).Start();
            }
            catch (Exception ex)
            {
                // We'll never get here!
                Console.WriteLine("Exception!");
            }
        }

        static void Go() { throw null; }   // Throws a NullReferenceException

        #endregion


        #region Correct way of applying try/catch/finally in threading.

        public static void Main()
        {
            new Thread(Go1).Start();
        }

        static void Go1()
        {
            try
            {
                // ...
                throw null;    // The NullReferenceException will get caught below
                // ...
            }
            catch (Exception ex)
            {
                // Typically log the exception, and/or signal another thread
                // that we've come unstuck
                // ...
            }
        }
        #endregion

        


    }
}
