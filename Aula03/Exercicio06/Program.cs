using System;
using System.Collections.Generic;

namespace Exercicio06
{
    /// <summary>
    /// Test how to sort stuff in a collection.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Program starts here.
        /// </summary>
        /// <param name="args">Not used.</param>
        public static void Main(string[] args)
        {
            // The option selected by the user
            string option;
            // The list of players, initially empty
            List<Player> players = new List<Player>();

            // Main menu loop
            do
            {
                // Get option from user
                option = Menu();
                // Check option
                switch (option)
                {                    
                    case "i": // Insert player option
                        InsertPlayer(players);
                        break;
                    case "l": // List players option
                        ListPlayers(players);
                        break;
                    case "q": // Quit
                        break;
                    default: // Unknown option
                        Console.WriteLine("Unknown option!");
                        break;
                }
                // Keep looping until user quits
            } while (option != "q");

        }

        /// <summary>
        /// Show main menu and get user option.
        /// </summary>
        /// <returns>User option.</returns>
        private static string Menu()
        {
            // Show menu
            Console.WriteLine("------------------");
            Console.WriteLine("(I)nsert player");
            Console.WriteLine("(L)ist players");
            Console.WriteLine("(Q)uit");
            Console.WriteLine("------------------");
            // Ask and return player option, removing whitespace before and
            // after the option and converting the option to lowercase
            return Console.ReadLine().Trim().ToLower();
        }

        /// <summary>
        /// Insert a player in the list.
        /// </summary>
        /// <param name="players">The list of players.</param>
        private static void InsertPlayer(List<Player> players)
        {
            // Required local variables
            string playerName, playerScoreStr;
            int playerScore;
            Player player;

            // Get player name
            Console.Write("Player name  : ");
            playerName = Console.ReadLine();

            // Get player score, must be valid integer
            while (true)
            {
                Console.Write("Player score : ");
                playerScoreStr = Console.ReadLine();

                // Check if score is valid integer
                if (int.TryParse(playerScoreStr, out playerScore))
                {
                    // If so, get out of loop
                    break;
                }
                // If not, show error message
                Console.WriteLine("Invalid integer, please try again");
            };

            // Instantiate new player (using property initialization syntax)
            player = new Player() { Name = playerName, Score = playerScore };

            // Add player to list
            players.Add(player);
        }

        /// <summary>
        /// List all players, sorted by score.
        /// </summary>
        /// <param name="players">The players list.</param>
        private static void ListPlayers(List<Player> players)
        {
            // Sort players
            players.Sort();

            // Show player list
            Console.WriteLine("==== Player List ====");
            foreach (Player player in players)
            {
                // We're using the Player.ToString() method to show player info
                Console.WriteLine(player);
            }
            Console.WriteLine("=====================");
        }
    }
}
