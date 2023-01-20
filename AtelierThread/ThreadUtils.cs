using System;
using System.Threading;

namespace AtelierThreads
{
    class ThreadUtils
    {

        private static readonly Random rand = new Random();

        private static int[] GenererTableau(int taille)
        {
            int[] t = new int[taille];
            for (int i = 0; i < t.Length; i++)
            {
                t[i] = rand.Next(int.MinValue, int.MaxValue);
            }
            return t;
        }

        public static void PedalerDansLeVide(int taille)
        {
            Array.Sort(GenererTableau(taille));
        }

        public static void ImprimerInfoThread()
        {
            Thread t = Thread.CurrentThread;
            Console.WriteLine($"**ID : {t.ManagedThreadId} , " +
                $"Priorité : {t.Priority}, " +
                $"Est background : {t.IsBackground}, ");
        }
    }
}
