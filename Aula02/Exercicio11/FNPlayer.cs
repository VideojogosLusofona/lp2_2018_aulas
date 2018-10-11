namespace Exercicio10
{
    /// <summary>
    /// Class that represents a Fortnite player.
    /// </summary>
    public abstract class FNPlayer
    {

        /// <summary>
        /// Maximum health for all instances of the `FNPlayer`class,
        /// represented by a static auto-implemented property.
        /// </summary>
        public static float MaxHealth { get; set; } = 100;

        /// <summary>
        /// The player's health.
        /// It's a private instance variable which supports the public Health
        /// property.
        /// </summary>
        protected float health;

        /// <summary>
        /// A property representing the player's health. It uses the `health`
        /// instance variable as support. Publicly readable, but only can only
        /// be changed within the class or by subclasses.
        /// </summary>
        public virtual float Health
        {

            // This is the property's `get` block
            get { return health; }

            // This is the property's `set` block
            protected set
            {
                // `value` is a special variable available in a property `set`
                // block
                if (value <= 0)
                {
                    // If health is zero or less, player is set as dead
                    Die();
                }
                else if (value >= MaxHealth)
                {
                    // If health is more than the maximum health allowed for
                    // all player instances, limit health to this maximum.
                    health = MaxHealth;
                }
                else
                {
                    // Set initial health (if it is between 0 and MaxHealth)
                    health = value;
                }
            }
        }

        /// <summary>
        /// The player's weapon. Publicly readable, but only can only be
        /// changed within the class or by subclasses.
        /// </summary>
        public string Weapon { get; protected set; }

        /// <summary>
        /// Is the player alive? Publicly readable, but only can only be
        /// changed within the class or by subclasses.
        /// </summary>
        public bool Alive { get; protected set; }

        /// <summary>
        /// This constructor initializes player health and weapon with values
        /// specified by the code who creates a new player instance. It is 
        /// protected because only subclasses should be able to call it in this
        /// case.
        /// </summary>
        /// <param name="health">Initial player health.</param>
        /// <param name="weapon">Initial player weapon.</param>
        protected FNPlayer(float health, string weapon)
        {
            // We now use the property to set the player's health, so that the
            // property's `set` block validates the specified health.
            Health = health;

            // Set initial weapon
            Weapon = weapon;

            // The 'this' keyword differentiates between the instance
            // variables and the local variables/parameters

            // Set player alive
            Alive = true;
        }

        /// <summary>
        /// Attack an enemy.
        /// </summary>
        /// <param name="enemy">Enemy to attack.</param>
        public abstract void Attack(FNPlayer enemy);

        /// <summary>
        /// Take damage from an enemy or possibly something else.
        /// </summary>
        /// <param name="damage">Damage to take.</param>
        public void TakeDamage(float damage)
        {
            // Lose health in the amount specified by the damage variable
            Health -= damage;
        }

        /// <summary>
        /// Kill this player.
        /// </summary>
        public void Die()
        {
            health = 0;
            Alive = false;
        }

        /// <summary>
        /// Return a string with information about the player.
        /// </summary>
        /// <param name="player">
        /// A string with information about the player
        /// </param>
        public override string ToString()
        {
            return string.Format(
                "{0} is {1} => Health is {2} and Weapon is {3}",
                GetType().Name,
                Alive ? "alive" : "dead",
                Health,
                Weapon);
        }
    }
}
