using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Exercicio3
{
    /// <summary>
    /// Solução do exercício 3 da aula 9. Neste caso criamos uma instância da
    /// classe Program para não estarmos a utilizar tudo static, pois isso não
    /// é boa prática.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Coleção thread-safe que vamos utilizar para passar as teclas lidas
        /// do produtor para o consumidor.
        /// </summary>
        private readonly BlockingCollection<ConsoleKey> queue;

        /// <summary>Programa começa aqui.</summary>
        static void Main()
        {
            Program prog = new Program();
            prog.Start();
        }

        /// <summary>Constroi uma instância da classe Program.</summary>
        public Program()
        {
            //  Instanciar a coleção thread-safe; por omissão esta coleção
            // utiliza uma fila, mas isto pode ser alterado invocando outro
            // overload do construtor
            queue = new BlockingCollection<ConsoleKey>();
        }

        /// <summary>Inicia o programa propriamente dito.</summary>
        private void Start()
        {
            // Declarar e instanciar thread produtora (coloca teclas na
            // coleção) e thread consumidora (retira teclas da coleção)
            Thread prodThread = new Thread(Producer);
            Thread consThread = new Thread(Consumer);

            // Iniciar threads
            prodThread.Start();
            consThread.Start();

            // Esperar que as threads terminem
            prodThread.Join();
            consThread.Join();
        }

        /// <summary>
        /// Método que lê teclas do teclado e coloca-as na fila thread-safe.
        /// </summary>
        private void Producer()
        {
            // Variável onde colocar teclas lidas do teclado
            ConsoleKey key;

            // Ler teclas do teclado enquanto utilizador não carregar no Escape 
            do
            {
                // Ler tecla do teclado, omitindo o echo dessa tecla no ecrã
                key = Console.ReadKey(true).Key;

                // Enviar tecla lida para a fila thread-safe
                queue.Add(key);

            } while (key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Método que retira teclas da fila thread-safe e age sobre elas.
        /// </summary>
        private void Consumer()
        {
            // Variável onde colocar teclas retiradas da fila thread-safe
            ConsoleKey key;

            // Ler teclas da fila enquanto a tecla lida não for o Escape
            while ((key = queue.Take()) != ConsoleKey.Escape)
            {
                if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
                {
                    Console.WriteLine("Cima");
                }
                else if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
                {
                    Console.WriteLine("Baixo");
                }
                else if (key == ConsoleKey.D || key == ConsoleKey.RightArrow)
                {
                    Console.WriteLine("Direita");
                }
                else if (key == ConsoleKey.A || key == ConsoleKey.LeftArrow)
                {
                    Console.WriteLine("Esquerda");
                }
            }
        }
    }
}
