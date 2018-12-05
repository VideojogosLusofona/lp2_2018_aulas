using System;

namespace Exercicio1
{
    // Classe que implementa comportamento de quack mudo
    public class MuteQuack : IQuackBehaviour
    {
        public void Quack()
        {
            // Comportamento de quack mudo: não faz barulho
            Console.WriteLine("(silence)");
        }
    }
}