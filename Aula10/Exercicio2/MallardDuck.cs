using System;

namespace Exercicio2
{
    public class MallardDuck : Duck
    {
        // Construtor, define que mallard duck faz quacks normais e voa
        // normalmente
        public MallardDuck()
        {
            QuackBehaviour = () => Console.WriteLine("(silence)");
            FlyBehaviour =
                () => Console.WriteLine("I'm flying with my wings :D");
        }

        // Mostrar o mallard duck
        public override void Display()
        {
            Console.WriteLine("I'm a Mallard Duck");
        }
    }
}
