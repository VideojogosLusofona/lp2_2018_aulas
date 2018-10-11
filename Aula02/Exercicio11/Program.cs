using System;

namespace Exercicio10
{
    /// <summary>
    /// This class tests the concrete Fortnite player classes.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Program starts here.
        /// </summary>
        /// <param name="args">Not used.</param>
        public static void Main(string[] args)
        {

            // Create instances of each player class
            FNPlayer p1 = new Berserker(150, "Pickaxe");
            FNPlayer p2 = new Demolitionist(100);

            // Info before the fight beging
            Console.WriteLine(" == Before the fight begins == ");
            Console.WriteLine($"{p1}\n{p2}\n");

            // Do some battles
            PerformAttack(p1, p2);
            PerformAttack(p2, p1);
            PerformAttack(p1, p2);
            PerformAttack(p1, p1);
            PerformAttack(p2, p1);
            PerformAttack(p2, p1);
            PerformAttack(p2, p1);

        }

        /// <summary>
        /// Static method which performs an attack.
        /// </summary>
        /// <param name="p1">Player who performs the attack.</param>
        /// <param name="p2">Player who suffers the attack.</param>
        private static void PerformAttack(FNPlayer p1, FNPlayer p2)
        {
            // Determine player classes
            string p1class = p1.GetType().Name;
            string p2class = p1 != p2 ? p2.GetType().Name : "himself";

            // Perform attack and show info
            Console.WriteLine($" == {p1class} attacks {p2class} == ");
            p1.Attack(p2);
            Console.WriteLine($"{p1}\n{p2}\n");
        }
    }
}
