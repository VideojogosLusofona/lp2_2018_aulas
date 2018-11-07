namespace Exercicio6
{
    /// <summary>
    /// A gun silencer, which is a weapon decorator.
    /// </summary>
    public class GunSilencer : GunDecorator
    {
        /// <summary>
        /// The silencer decorator decreases the noise produced when firing a
        /// gun.
        /// </summary>
        public override float NoiseLevel
        {
            get
            {
                return DecoratedGun.NoiseLevel * noisePercentage;
            }
        }

        /// <summary>
        /// The percentage of noise produced after applying this decorator.
        /// </summary>
        private readonly float noisePercentage;

        /// <summary>
        /// Creates a new instance of a silencer decorator.
        /// </summary>
        /// <param name="gun">
        /// The gun to decorate. This parameter is passed to the base class
        /// constructor.
        /// </param>
        /// <param name="noisePercentage">
        /// The percentage of noise produced after applying this decorator.
        /// </param>
        public GunSilencer(Gun gun, float noisePercentage) : base(gun)
        {
            this.noisePercentage = noisePercentage;
        }

        /// <summary>
        /// Returns a rendering of the decorated gun with a silencer.
        /// </summary>
        /// <returns>
        /// A rendering of the decorated gun with a silencer.
        /// </returns>
        public override string GetRender()
        {
            // We cheat, since we only return a string and not a real 3D model
            return DecoratedGun.GetRender() + " + silencer";
        }
    }
}
