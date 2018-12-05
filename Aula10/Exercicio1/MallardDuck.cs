using System;

namespace Exercicio1
{
    public class MallardDuck : Duck
    {
        // Construtor, define que mallard duck faz quacks normais e voa
        // normalmente
        public MallardDuck()
        {
            QuackBehaviour = new NormalQuack();
            FlyBehaviour = new FlyWithWings();
        }

        // Mostrar o mallard duck
        public override void Display()
        {
            Console.WriteLine("I'm a Mallard Duck");
        }
    }
}
