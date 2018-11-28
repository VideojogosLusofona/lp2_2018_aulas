using System;
using System.Threading;

namespace Exercicio2
{
    /// <summary>
    /// Resolução do exercício 2 da aula 9 de LP2.
    /// </summary>
    class Program
    {
        /// <summary>Número de saltos da cada rã.</summary>
        public const int numJumps = 10;

        /// <summary>Duração máxima entre saltos (em milisegundos).</summary>
        public const int maxTimeBtwJumps = 1000;

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

            // Obter seed para gerador de numeros aleatorios:
            // - Usar a frogID garante uma seed diferente para cada rã
            // - Usar o tempo atual em milisegundos garante seeds diferentes
            //   em cada execução do programa
            // - A operação ^ (XOR) mistura bem os bits das duas componentes,
            //   garantindo seeds bem diferentes para cada rã
            int seed = frogId ^ DateTime.Now.Millisecond;

            // Iniciar gerador de números aleatórios com a seed calculada
            Random rnd = new Random(seed);

            // Entrar no ciclo de saltos da rã
            for (int i = 0; i < numJumps; i++)
            {
                // Tempo aleatório até ao próximo salto
                int timeBtwJumps;
                
                // Mostrar mensagem da rã para o salto atual
                Console.WriteLine($"Rã #{frogId} deu salto #{i + 1}");

                // Obter tempo aleatório até ao próximo salto
                timeBtwJumps = rnd.Next(maxTimeBtwJumps);

                // Esperar um tempo aleatório até ao próximo salto
                Thread.Sleep(timeBtwJumps);
            }
        }
    }
}
