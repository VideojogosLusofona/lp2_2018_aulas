using System;

namespace Exercicio2
{
    public class RedheadDuck : Duck
    {
        // Construtor, define que redhead duck faz quacks normais e voa
        // normalmente
        public RedheadDuck()
        {
            QuackBehaviour = () => Console.WriteLine("(silence)");
            FlyBehaviour = 
                () => Console.WriteLine("I'm flying with my wings :D");
        }

        // Mostrar o redhead duck
        public override void Display()
        {
            Console.WriteLine("I'm a Redhead Duck");
        }
    }
}
