using System;

namespace Exercicio1
{
    // Classe que implementa um comportamento de não-voo
    public class FlyNoWay : IFlyBehaviour
    {
        public void Fly()
        {
            // Este comportamento define que não há voo
            Console.WriteLine("Can't fly :´(");
        }
    }
}