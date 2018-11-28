using System;
using System.Threading;

namespace Exercicio2
{
    /// <summary>
    /// Resolução alternativa do exercício 2 da aula 9 de LP2, com a instância
    /// de Random partilhada entre threads.
    /// </summary>
    class Program
    {
        /// <summary>Número de saltos da cada rã.</summary>
        public const int numJumps = 10;

        /// <summary>Duração máxima entre saltos (em milisegundos).</summary>
        public const int maxTimeBtwJumps = 1000;

        /// <summary>
        /// Instância de Random que será partilhada entre as threads.
        /// </summary>
        private static Random rnd;

        /// <summary>
        /// Objeto que servirá de lock para acesso concorrente à instância de
        /// Random.
        /// </summary>
        private static object rndLock;

        /// <summary>
        /// Construtor para os membros static da classe Program (invocado
        /// automaticamente).
        /// </summary>
        static Program()
        {
            // Uma vez que as threads vão partilhar o gerador de números
            // aleatórios, não é necessário nenhuma seed em especial
            rnd = new Random();
            rndLock = new object();
        }

        /// <summary>
        /// O programa começa aqui.
        /// </summary>
        public static void Main()
        {
            // Criar as threads
            Thread t1 = new Thread(FrogBehaviour);
            Thread t2 = new Thread(FrogBehaviour);
            Thread t3 = new Thread(FrogBehaviour);

            // Iniciar as threads, passando-lhes o ID das rãs
            t1.Start(1); // Rã 1
            t2.Start(2); // Rã 2
            t3.Start(3); // Rã 3

            // Esperar pelas threads
            t1.Join();
            t2.Join();
            t3.Join();
        }

        /// <summary>
        /// Método que define o comportamento de cada rã. Vai ser executado
        /// de forma independente dentro de diferentes threads. Este método é
        /// compatível com o delegate ParameterizedThreadStart de modo a poder
        /// ser executado dentro de uma thread.
        /// </summary>
        /// <param name="obj">O ID da rã, sob a forma de objeto.</param>
        private static void FrogBehaviour(object obj)
        {
            // Obter ID da rã
            int frogId = (int)obj;

            // Entrar no ciclo de saltos da rã
            for (int i = 0; i < numJumps; i++)
            {
                // Tempo aleatório até ao próximo salto
                int timeBtwJumps;

                // Mostrar mensagem da rã para o salto atual
                Console.WriteLine($"Rã #{frogId} deu salto #{i + 1}");

                // Uma vez que a instância de Random está partilhada entre as
                // várias threads, e como a classe Random não é thread-safe,
                // temos de controlar o acesso à mesma de modo a que apenas
                // uma thread possa ter acesso de cada vez
                lock (rndLock)
                {
                    // Obter tempo aleatório até ao próximo salto
                    timeBtwJumps = rnd.Next(maxTimeBtwJumps);
                }

                // Esperar um tempo aleatório até ao próximo salto
                Thread.Sleep(timeBtwJumps);
            }
        }
    }
}
