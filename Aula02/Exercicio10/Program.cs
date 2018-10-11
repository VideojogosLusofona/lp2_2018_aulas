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
            PrintPlayerInfo(p1);
            PrintPlayerInfo(p2);
            Console.WriteLine();

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
            PrintPlayerInfo(p1);
            PrintPlayerInfo(p2);
            Console.WriteLine();
        }

        /// <summary>
        /// Helper method to print player info.
        /// </summary>
        /// <param name="player"></param>
        private static void PrintPlayerInfo(FNPlayer player)
        {
            Console.WriteLine("{0} is {1} => Health is {2} and Weapon is {3}",
                player.GetType().Name,
                player.Alive ? "alive" : "dead",
                player.Health,
                player.Weapon);
        }
    }
}
