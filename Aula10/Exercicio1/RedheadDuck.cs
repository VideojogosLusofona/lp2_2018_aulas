using System;

namespace Exercicio1
{
    public class RedheadDuck : Duck
    {
        // Construtor, define que redhead duck faz quacks normais e voa
        // normalmente
        public RedheadDuck()
        {
            QuackBehaviour = new NormalQuack();
            FlyBehaviour = new FlyWithWings();
        }

        // Mostrar o redhead duck
        public override void Display()
        {
            Console.WriteLine("I'm a Redhead Duck");
        }
    }
}
