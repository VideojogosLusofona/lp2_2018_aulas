namespace Exercicio10
{

    /// <summary>
    /// Class that represents the Berserker player class in Fortnite.
    /// </summary>
    public class Berserker : FNPlayer
    {
        /// <summary>
        /// The damage caused by the berserker.
        /// </summary>
        public const int damage = 20;

        /// <summary>
        /// A property representing the player's health.
        /// </summary>
        public override float Health
        {

            // This is the property's `get` block
            get { return health; }

            // This is the property's `set` block; the Berserker class never
            // dies and can have health up to 2 times the maximum
            protected set
            {
                // `value` is a special variable available in a property `set`
                // block
                if (value <= 0)
                {
                    // If health is zero or less, set health to one; Berserkers
                    // never die
                    health = 1;
                }
                else if (value >= 2 * MaxHealth)
                {
                    // If health is more than two times the maximum health
                    // allowed for other players, limit health to this value
                    health = 2 * MaxHealth;
                }
                else
                {
                    // Set health (if it is between 0 and 2 * MaxHealth)
                    health = value;
                }
            }
        }

        /// <summary>
        /// This constructor initializes player health and weapon with values
        /// specified by the code who creates a new player instance.
        /// </summary>
        /// <param name="health">Initial player health.</param>
        /// <param name="weapon">Initial player weapon.</param>
        public Berserker(float health, string weapon) : base(health, weapon)
        {
            // All the stuff is done by the base constructor
        }

        /// <summary>
        /// Attack an enemy.
        /// </summary>
        /// <param name="enemy">Enemy to attack.</param>
        public override void Attack(FNPlayer enemy)
        {
            // Berserker causes causes the damage specified in the constant
            enemy.TakeDamage(damage);
        }

        /// <summary>
        /// Return a string with information about the demolitionist player.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{base.ToString()}, Damage is {damage}";
        }
    }
}
