using System;

namespace Exercicio1
{
    // Classe que implementa comportamento de quack normal
    public class NormalQuack : IQuackBehaviour
    {
        public void Quack()
        {
            // Quack normal
            Console.WriteLine("Quack!");
        }
    }
}