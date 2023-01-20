using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AtelierThreads
{
    public class ExempleDeadLock
    {

        public static string phrase = "";
        public static Random random = new Random();

        public static readonly object verrou1 = new object();
        public static readonly object verrou2 = new object();

        public const int NB_LETTRES = 50;

        public static void RunExempleDeadLock()
        {
            Task a = Task.Run(MethodeA);
            Task b = Task.Run(MethodeB);

            Task.WaitAll(a, b);

            Console.WriteLine($"\nPhrase {(phrase.Length)} = {phrase}");
        }

        public static void MethodeA()
        {
            lock (verrou1)
            {
                Thread.Sleep(0);
                lock (verrou2)
                {
                    for (int i = 0; i < NB_LETTRES; i++)
                    {
                        Thread.Sleep(random.Next(100));
                        Console.Write(".");
                        phrase += "A";
                    }
                }
            }
        }

        public static void MethodeB()
        {
            lock (verrou2)
            {
                Thread.Sleep(0);
                lock (verrou1)
                {
                    for (int i = 0; i < NB_LETTRES; i++)
                    {
                        Thread.Sleep(random.Next(100));
                        Console.Write(".");
                        phrase += "B";
                    }
                }
            }
        }
    }
}
