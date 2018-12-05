using System;

namespace Exercicio2
{
    public class RubberDuck : Duck
    {
        // Construtor, define que um rubber duck faz "squeak" e não voa
        public RubberDuck()
        {
            QuackBehaviour = () => Console.WriteLine("(silence)");
            FlyBehaviour = () => Console.WriteLine("Squeak!");
        }

        // Mostrar o rubber duck
        public override void Display()
        {
            Console.WriteLine("I'm a Rubber Duck");
        }
    }
}
