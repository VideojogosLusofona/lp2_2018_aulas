﻿namespace Exercicio10
{
    /// <summary>
    /// Class which represents a player, which has a name and a score.
    /// </summary>
    public class Player : IHasScore
    {
        /// <summary>
        /// Instance variable that contains the actual score and supports the
        /// Score property.
        /// </summary>
        private int score;

        /// <summary>
        /// The Score property, in accordance with the IHasScore interface.
        /// For this class, Score can never be less than zero.
        /// </summary>
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                // Make sure score is never less than zero
                if (value < 0)
                {
                    score = 0;
                }
                else
                {
                    score = value;
                }
            }
        }

        /// <summary>
        /// Auto-implemented property that represents the player's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This method is required by the <see cref="IComparable{T}"/>
        /// interface, so that players can be compared.
        /// </summary>
        /// <param name="other">
        /// The player to which the current player is to be compared with.
        /// </param>
        /// <returns>
        /// -1 if this player comes before the other.
        ///  0 if players have a similar score.
        ///  1 if this player comes after the other.
        ///  </returns>
        public int CompareTo(IHasScore other)
        {
            if (other == null) return -1;
            return other.Score - Score;
        }

        /// <summary>
        /// This method returns true if another instance of type IHasScore
        /// contains the same score as the current instance.
        /// </summary>
        /// <param name="other">
        /// An instance of a class that implements the IHasScore interface.
        /// </param>
        /// <returns>True if both instances have the same score.</returns>
        public bool Equals(IHasScore other)
        {
            if (other == null) return false;
            return Score == other.Score;
        }

        /// <summary>
        /// <see cref="object.ToString()"/>
        /// </summary>
        /// <returns>A string representing the player.</returns>
        public override string ToString()
        {
            return string.Format("{0,-10} {1,5:d}", Name, Score);
        }
    }
}
