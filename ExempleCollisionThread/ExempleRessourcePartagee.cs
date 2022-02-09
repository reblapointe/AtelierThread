using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AtelierThreads
{
    public class ExempleRessourcePartagee
    {
        public static string phrase = "";
        public static Random random = new Random();
        public static readonly object verrouA = new object();
        public static readonly object verrouB = new object();

        public const int NB_LETTRES = 50;

        public static void RunExempleCollision()
        {
            Task a = Task.Run(MethodeA);
            Task b = Task.Run(MethodeB);
            Task c = Task.Run(MethodeC);

            Task[] tasks = { a, b, c };

            Task.WaitAll(tasks);

            Console.WriteLine($"\nPhrase {(phrase.Length)} = {phrase}");
        }

        public static void MethodeA()
        {
            lock (verrouA)
            {
                for (int i = 0; i < NB_LETTRES; i++)
                {
                    Thread.Sleep(random.Next(100));
                    Console.Write(".");
                    phrase += "A";
                }
            }
        }

        public static void MethodeB()
        {
            lock (verrouB)
            {
                for (int i = 0; i < NB_LETTRES; i++)
                {
                    Thread.Sleep(random.Next(100));
                    Console.Write(".");
                    phrase += "B";
                }
            }
        }

        public static void MethodeC()
        {
            lock (verrouB) lock (verrouA)
                {
                    for (int i = 0; i < NB_LETTRES; i++)
                    {
                        Thread.Sleep(random.Next(100));
                        Console.Write(".");
                        phrase += "C";

                    }
                }
        }
    }
}
