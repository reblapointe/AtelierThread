using System;
using BenchmarkDotNet.Running;
using System.Diagnostics;

using System.Threading;
using System.Threading.Tasks;

namespace AtelierThreads
{
    class Program
    {
        public static void Main(string[] args)
        {
            // BenchmarkRunner.Run<StringBenchmarkPerformance>();

            Stopwatch timer = Stopwatch.StartNew();
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Exemple sans threads");
           // ExemplePasDeThreads.RunExemplePasDeThreads();
            Console.WriteLine($"Il s'est écoulé {timer.ElapsedMilliseconds} ms");
            timer.Restart();

            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Exemple avec threads");
           // ExempleThreadsManages.RunExempleThreadsManages();
            Console.WriteLine($"Il s'est écoulé {timer.ElapsedMilliseconds:#0} ms");
            timer.Restart();

            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Exemple avec ressource partagée");
            ExempleRessourcePartagee.RunExempleCollision();
            Console.WriteLine($"Il s'est écoulé {timer.ElapsedMilliseconds:#0} ms");
            timer.Restart();
        }


    }
}
