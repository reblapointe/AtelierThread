using System;
using System.Threading;

namespace AtelierThreads
{
    class ThreadUtils
    {
        public static void ImprimerInfoThread()
        {
            Thread t = Thread.CurrentThread;
            Console.WriteLine($"**ID : {t.ManagedThreadId} , " +
                $"Priorité : {t.Priority}, " +
                $"Est background : {t.IsBackground}, ");
        }
    }
}
