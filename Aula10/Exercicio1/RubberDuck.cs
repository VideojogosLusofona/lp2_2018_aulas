using System;

namespace Exercicio1
{
    public class RubberDuck : Duck
    {
        // Construtor, define que um rubber duck faz "squeak" e não voa
        public RubberDuck()
        {
            QuackBehaviour = new Squeak();
            FlyBehaviour = new FlyNoWay();
        }

        // Mostrar o rubber duck
        public override void Display()
        {
            Console.WriteLine("I'm a Rubber Duck");
        }
    }
}
