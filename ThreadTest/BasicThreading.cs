using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    class BasicThreading
    {
        /// <summary>
        /// Multithreading is managed internally by a thread scheduler.
        /// A function that CLR typically delegates to operating system.
        /// Thread scheduler ensures all active threads are allocated appropriate execution time
        /// and makes sure that theads waiting or blocked do not consume CPU resources or time.
        /// By default all threads are FOREGROUND threads.These threads keep application alive.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)//"main" thread created by CLR and OS.
        {
            Thread t = new Thread(WriteY);
            //Naming threads
            t.Name = "BasicWorker";
            t.Start();

            //simultaneously do something on the "main" thread
            for(int i=0;i<100;i++)
            {
                Console.WriteLine("X");
            }
        }

        /// <summary>
        /// this method runs on worker thread.
        /// </summary>
        private static void WriteY()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Y");
            }
        }
    }
}
