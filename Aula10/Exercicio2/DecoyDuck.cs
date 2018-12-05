using System;

namespace Exercicio2
{
    public class DecoyDuck : Duck
    {
        // Construtor, define que um decoy duck não faz barulho e não voa
        public DecoyDuck()
        {
            QuackBehaviour = () => Console.WriteLine("(silence)");
            FlyBehaviour = () => Console.WriteLine("Can't fly :´(");
        }

        // Mostrar o decoy duck
        public override void Display()
        {
            Console.WriteLine("I'm a Decoy Duck");
        }
    }
}
