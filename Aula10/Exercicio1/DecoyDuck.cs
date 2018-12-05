using System;

namespace Exercicio1
{
    public class DecoyDuck : Duck
    {
        // Construtor, define que um decoy duck não faz barulho e não voa
        public DecoyDuck()
        {
            QuackBehaviour = new MuteQuack();
            FlyBehaviour = new FlyNoWay();
        }

        // Mostrar o decoy duck
        public override void Display()
        {
            Console.WriteLine("I'm a Decoy Duck");
        }
    }
}
