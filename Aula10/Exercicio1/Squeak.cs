using System;

namespace Exercicio1
{
    // Classe que implementa um squeak
    public class Squeak : IQuackBehaviour
    {
        public void Quack()
        {
            // Não é um quack, é um squeak!
            Console.WriteLine("Squeak!");
        }
    }
}