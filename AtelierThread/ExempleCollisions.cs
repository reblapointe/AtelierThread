using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AtelierThreads
{
    public class ExempleCollision
    {
        private class RessourcePartagee
        {
            private int compteur;
            private readonly object verrou = new object();

            public int GetCompteur()
            {
                return compteur;
            }

            public void Init()
            {
                compteur = 0;
            }

            public void Incrementer()
            {
                compteur++;
            }

            public void IncrementerAtomic()
            {
                Interlocked.Increment(ref compteur);
            }

            public void IncrementerLock()
            {
                lock (verrou)
                    compteur++;
            }
        }

        private readonly RessourcePartagee ressourcePartagee = new RessourcePartagee();

        public const int NB_THREADS = 15;
        public const int NB_INCREMENTATIONS = 1_000_000;


        [Benchmark(Baseline = true)]
        public void DemarrerExempleCollision()
        {
            ressourcePartagee.Init();
            DemarrerExemple(() => ressourcePartagee.Incrementer());
        }

        [Benchmark]
        public void DemarrerExempleCollisionLock()
        {
            ressourcePartagee.Init();
            DemarrerExemple(() => ressourcePartagee.IncrementerLock());
        }

        [Benchmark]
        public void DemarrerExempleCollisionAtomic()
        {
            ressourcePartagee.Init();
            DemarrerExemple(() => ressourcePartagee.IncrementerAtomic());
        }

        public void DemarrerExemple(Action a)
        {
            Task[] tasks = new Task[NB_THREADS];
            for (int i = 0; i < tasks.Length; i++)
                tasks[i] = Task.Run(() =>
                {
                    for (int i = 0; i < NB_INCREMENTATIONS; i++)
                        a.Invoke();
                });

            Task.WaitAll(tasks);

            Console.WriteLine($"Compteur = {ressourcePartagee.GetCompteur()}");

        }
    }
}
