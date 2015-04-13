using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    /// <summary>
    /// You can wait for another thread to end by calling its Join method
    /// </summary>
    class ThreadJoinAndSleep
    {
        static void Main()
        {
            Thread t = new Thread(Go);
            t.Start();
            t.Join();
            Console.WriteLine("Thread t has ended!");
        }

        /// <summary>
        /// This prints “y” 1,000 times, followed by “Thread t has ended!” immediately afterward. 
        /// You can include a timeout when calling Join, either in milliseconds or as a TimeSpan. It then returns true if the thread ended or false if it timed out.
        ///Thread.Sleep pauses the current thread for a specified period:

        /// Thread.Sleep (TimeSpan.FromHours (1));  // sleep for 1 hour
        /// Thread.Sleep (500);                     // sleep for 500 milliseconds
        // While waiting on a Sleep or Join, a thread is blocked and so does not consume CPU resources.
        /// </summary>
        static void Go()
        {
            for (int i = 0; i < 1000; i++) Console.Write("y");
        }
    }
}
