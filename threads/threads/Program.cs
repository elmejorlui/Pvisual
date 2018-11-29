using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Threads
{
    public class hilos
    {
        static readonly object firstLock = new object();
        static readonly object secondLock = new object();
        static Stopwatch contador1;
        static Stopwatch contador2;


        static void ThreadJob()
        {
            contador1 = Stopwatch.StartNew();
            Console.WriteLine("\t\t\t\tLocking firstLock");
            lock (firstLock)
            {
                Console.WriteLine("\t\t\t\tLocked firstLock");
                // Wait until we're fairly sure the first thread
                // has grabbed secondLock
                Thread.Sleep(1000);
                Console.WriteLine("\t\t\t\tLocking secondLock");
                lock (secondLock)
                {
                    Console.WriteLine("\t\t\t\tLocked secondLock");
                }
                Console.WriteLine("\t\t\t\tReleased secondLock");
            }
            Console.WriteLine("\t\t\t\tReleased firstLock");
            Console.WriteLine("\t\t\t\thilo1: " + contador1.ElapsedMilliseconds);
        }

        static void Main()
        {
            contador2 = Stopwatch.StartNew();
            new Thread(new ThreadStart(ThreadJob)).Start();
            // Wait until we're fairly sure the other thread
            // has grabbed firstLock
            Thread.Sleep(1050);
            Console.WriteLine("Locking secondLock");
            lock (secondLock)
            {
                Console.WriteLine("Locked secondLock");
                Console.WriteLine("Locking firstLock");
                lock (firstLock)
                {
                    Console.WriteLine("Locked firstLock");
                }
                Console.WriteLine("Released firstLock");
            }
            Console.WriteLine("Released secondLock");
            Console.WriteLine("hilo2: " + contador2.ElapsedMilliseconds);
            Console.Read();
        }
    }
}
