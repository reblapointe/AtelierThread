using System;
using BenchmarkDotNet.Running;
using System.Diagnostics;

using System.Threading;
using System.Threading.Tasks;

namespace ExempleCollisionThread
{
    class Program
    {
        public static void Main(string[] args)
        {
            // BenchmarkRunner.Run<StringBenchmarkPerformance>();
           
            //ExemplePasDeThreads.RunExemplePasDeThreads();

            ExempleThreadsManages.RunExempleThreadsManages();

            ExempleCollision.RunExempleCollision();
        }


    }
}
