using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    /// <summary>
    /// Threads share heap memory with another thread
    /// </summary>
    class CLRAssignsEachThreadItsOwnMemoryStack
    {
        static void Main(string[] args)//"main" thread created by CLR and OS.
        {
            new Thread(Go).Start();// Call Go() on new worker thread
            Go();// Call Go() on main thread
        }

        /// <summary>
        /// prints 10 ? marks as each call has its own memory stack , therefore dulpicates the effort.
        /// A separate copy of the cycles variable is created on each thread's memory stack, and so the output is, predictably, ten question marks.
        /// </summary>
        private static void Go()
        {
            for (int cycles = 0; cycles < 5; cycles++)
            {
                Console.WriteLine("?");
            }
        }
    }
}
