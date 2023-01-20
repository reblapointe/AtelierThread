using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AtelierThreads
{
    class ExempleAvecEtSansThread
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

            Task.WaitAll(pain, cuirePain, casseTete);

            Console.WriteLine($"Le pain et le casse-tête sont prêts.");
        }

        public static void RunExemplePasDeThreads()
        {
            ThreadUtils.ImprimerInfoThread();

            Console.WriteLine("Début des méthodes une après l'autre");
            CuireDuPain();
            EcouterLaRadio();
            FaireUnCasseTete();

            Console.WriteLine($"Le pain et le casse-tête sont prêts.");
        }


        public static void PreparerPate()
        {
            Console.WriteLine("Je prepare la pâte à pain");
            ThreadUtils.ImprimerInfoThread();

            ThreadUtils.PedalerDansLeVide(30_000_000);
            Console.WriteLine("La pâte est prête");
        }

        public static void CuireDuPain()
        {
            Console.WriteLine("Le pain cuit...");
            ThreadUtils.ImprimerInfoThread();

            ThreadUtils.PedalerDansLeVide(50_000_000);
            Console.WriteLine("Le pain est cuit");
        }

        public static void EcouterLaRadio()
        {
            Console.WriteLine("Commencer à écouter la radio...");
            ThreadUtils.ImprimerInfoThread();

            ThreadUtils.PedalerDansLeVide(100_000_000);
            Console.WriteLine("Fin de l'émission de radio.");
        }

        public static void FaireUnCasseTete()
        {
            Console.WriteLine("Commencer le casse-tête...");
            ThreadUtils.ImprimerInfoThread();
            ThreadUtils.PedalerDansLeVide(100_000_000);
            Console.WriteLine("Le casse tête est terminé.");
        }
    }
}
