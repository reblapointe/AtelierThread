using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AtelierThreads
{
    class ExempleThreadsManages
    {
        public static void RunExempleThreadsManages()
        {

            // BenchmarkRunner.Run<StringBenchmarkPerformance>();
            ThreadUtils.ImprimerInfoThread();

            Console.WriteLine("Début des méthodes en parallèle");
            Task pain = Task.Run(PreparerPate);
            Task radio = Task.Run(EcouterLaRadio);
            Task cuirePain = pain.ContinueWith(antecedant => CuireDuPain());
            Task casseTete = pain.ContinueWith(antecedant => FaireUnCasseTete());

            Task[] tasks = { pain, cuirePain, casseTete };
            Task.WaitAll(tasks);

            Console.WriteLine($"Le pain et le casse-tête sont prêts.");
        }

        public static void PreparerPate()
        {
            Console.WriteLine("Je prepare la pâte à pain");
            ThreadUtils.ImprimerInfoThread();
            Thread.Sleep(3000); // On attend 3 secondes
            Console.WriteLine("La pâte est prête");
        }

        public static void CuireDuPain()
        {
            Console.WriteLine("Le pain cuit...");
            ThreadUtils.ImprimerInfoThread();
            Thread.Sleep(10000); // On attend 10 secondes
            Console.WriteLine("Le pain est cuit");
        }

        public static void EcouterLaRadio()
        {
            Console.WriteLine("Commencer à écouter la radio...");
            ThreadUtils.ImprimerInfoThread();
            Thread.Sleep(20000); // On attend 20 secondes
            Console.WriteLine("Fin de l'émission de radio.");
        }

        public static void FaireUnCasseTete()
        {
            Console.WriteLine("Commencer le casse-tête...");
            ThreadUtils.ImprimerInfoThread();
            Thread.Sleep(5000); // On attend 5 seconde
            Console.WriteLine("Le casse tête est terminé.");
        }
    }
}
