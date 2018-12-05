using System;

namespace Exercicio1
{
    // Classe que implementa voo normal
    public class FlyWithWings : IFlyBehaviour
    {
        public void Fly()
        {
            // Este comportamento define um voo normal
            Console.WriteLine("I'm flying with my wings :D");
        }
    }
}