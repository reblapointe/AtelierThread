using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExempleCollisionThread
{
    class ExemplePasDeThreads
    {
        public static void RunExemplePasDeThreads()
        {
            // BenchmarkRunner.Run<StringBenchmarkPerformance>();
            ThreadUtils.ImprimerInfoThread();
            Stopwatch timer = Stopwatch.StartNew();

            Console.WriteLine("Début des méthodes une après l'autre");
            CuireDuPain();
            EcouterLaRadio();
            FaireUnCasseTete();

            Console.WriteLine($"Le pain et le casse-tête sont prêts, il s'est écoulé {timer.ElapsedMilliseconds:#0} ms");
        }

        public static void CuireDuPain()
        {
            Console.WriteLine("Le pain cuit...");
            ThreadUtils.ImprimerInfoThread();
            Thread.Sleep(3000); // On attend 3 secondes
            Console.WriteLine("Le pain est cuit");
        }

        public static void EcouterLaRadio()
        {
            Console.WriteLine("Commencer à écouter la radio...");
            ThreadUtils.ImprimerInfoThread();
            Thread.Sleep(2000); // On attend 2 secondes
            Console.WriteLine("Fin de l'émission de radio.");
        }

        public static void FaireUnCasseTete()
        {
            Console.WriteLine("Commencer le casse-tête...");
            ThreadUtils.ImprimerInfoThread();
            Thread.Sleep(1000); // On attend 1 seconde
            Console.WriteLine("Le casse tête est terminé.");
        }
    }
}
