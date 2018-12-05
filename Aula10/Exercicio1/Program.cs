using System;

namespace Exercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Array de patos
            Duck[] ducks = new Duck[4];

            // Criar os diferentes patos, colocá-los no array
            ducks[0] = new MallardDuck();
            ducks[1] = new RedheadDuck();
            ducks[2] = new RubberDuck();
            ducks[3] = new DecoyDuck();

            // Mostrar o comportamento dos diferentes patos
            foreach (Duck duck in ducks)
            {
                DoDuckThings(duck);
            }

            // Alterar o comportamento do primeiro pato, o Mallard Duck
            ducks[0].FlyBehaviour = new FlyNoWay(); // Deixa de poder voar
            ducks[0].QuackBehaviour = null; // Colocar quack a null, o que acontece?

            // Mostrar comportamento modificado do Mallard Duck
            Console.WriteLine("\n-> Next duck will have changed behaviour!\n");
            DoDuckThings(ducks[0]);
        }

        // Método auxiliar para invocar os vários métodos de um pato
        private static void DoDuckThings(Duck duck)
        {
            Console.WriteLine($" ===== {duck.GetType().Name} =====");
            Console.Write("\t");
            duck.Display();
            Console.Write("\t");
            duck.PerformFly();
            Console.Write("\t");
            duck.PerformQuack();
        }
    }
}
