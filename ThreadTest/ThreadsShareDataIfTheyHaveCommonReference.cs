using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    /// <summary>
    /// Because both threads call Go() on the same ThreadsShareDataIfTheyHaveCommonReference instance, 
    /// they share the "done" field. This results in "Done" being printed once instead of twice:
    /// </summary>
    class ThreadsShareDataIfTheyHaveCommonReference
    {
        bool done;

        static void Main()
        {
            var tt = new ThreadsShareDataIfTheyHaveCommonReference();   // Create a common instance
            new Thread(tt.Go).Start();
            tt.Go();
        }

        // Note that Go is now an instance method
        void Go()
        {
            if (!done) { done = true; Console.WriteLine("Done"); }
        }
    }
}
