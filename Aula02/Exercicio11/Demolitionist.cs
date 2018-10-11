namespace Exercicio10
{
    /// <summary>
    /// Class that represents the Demolitionist player class in Fortnite.
    /// </summary>
    public class Demolitionist : FNPlayer
    {
        /// <summary>
        /// The damage caused by the demolitionist.
        /// </summary>
        public const int damage = 40;

        /// <summary>
        /// This constructor initializes player health with values
        /// specified by the code who creates a new player instance.
        /// The weapon for the Demolitionist is always TNT.
        /// </summary>
        /// <param name="health">Initial player health.</param>
        public Demolitionist(float health) : base(health, "TNT")
        {
            // All the stuff is done by the base constructor
        }

        /// <summary>
        /// Attack an enemy.
        /// </summary>
        /// <param name="enemy">Enemy to attack.</param>
        public override void Attack(FNPlayer enemy)
        {
            // Demolitionist causes the damage specified in the constant
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
