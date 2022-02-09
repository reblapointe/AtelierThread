using System;
using BenchmarkDotNet.Running;
using System.Diagnostics;


namespace AtelierThreads
{
    class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch timer = Stopwatch.StartNew();
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Exemple sans threads");
            ExemplePasDeThreads.RunExemplePasDeThreads();
            Console.WriteLine($"Il s'est écoulé {timer.ElapsedMilliseconds} ms");
            timer.Restart();

            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Exemple avec threads");
            ExempleThreadsManages.RunExempleThreadsManages();
            Console.WriteLine($"Il s'est écoulé {timer.ElapsedMilliseconds:#0} ms");
            timer.Restart();

            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Exemple avec ressource partagée");
            ExempleRessourcePartagee.RunExempleRessourcePartagee();
            Console.WriteLine($"Il s'est écoulé {timer.ElapsedMilliseconds:#0} ms");
            timer.Restart();

            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Exemple avec collision");
            new ExempleCollision().DemarrerExempleCollision();
            Console.WriteLine($"Il s'est écoulé {timer.ElapsedMilliseconds:#0} ms");
            timer.Restart();

            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Exemple avec verrou mort");
           // ExempleDeadLock.RunExempleDeadLock();
            Console.WriteLine($"Il s'est écoulé {timer.ElapsedMilliseconds:#0} ms");
            timer.Restart();

            BenchmarkRunner.Run<ExempleCollision>();
        }
    }
}
