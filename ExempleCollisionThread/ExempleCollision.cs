using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ExempleCollisionThread
{
    public class ExempleCollision
    {

        public class Compteur
        {
            private int valeur;

            public void Incrementer()
            {
                valeur++;
            }

            public int getValeur()
            {
                return valeur;
            }
        }

        private readonly Compteur compteur = new Compteur();

        public static void RunExempleCollision()
        {
            new ExempleCollision().RoulerDesThreads();
        }

        public void RoulerDesThreads()
        {
            int nbThreads = 15;

            Thread[] threads = new Thread[nbThreads];
            for (int i = 0; i < nbThreads; i++)
                threads[i] = new Thread(new ThreadStart(Conc));
            for (int i = 0; i < nbThreads; i++)
                threads[i].Start();
            for (int i = 0; i < nbThreads; i++)
                threads[i].Join();

            Console.WriteLine($"Compteur vaut {compteur.getValeur()}");
            Thread.Sleep(1000);

        }

        public void Conc()
        {
            for (int i = 0; i < 1_000_000; i++)
                compteur.Incrementer();
        }


    }
}
