using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    /// <summary>
    /// The problem is that one thread 
    /// can be evaluating the if statement right as the other thread is executing the WriteLine statement — before it’s had a chance to set done to true.
    /// </summary>
    class StaticFieldsAnotherWayOfSharingDataBtwThreads
    {
        static bool done;   // Static fields are shared between all threads

        static void Main()
        {
            new Thread(Go).Start();
            Go();
        }
        //But what abt thread safety ??. Done could be printed twice, therefore we could use locks
        static void Go()
        {
            if (!done) 
            { 
                done = true; 
                Console.WriteLine("Done"); 
            }
        }
    }
}
