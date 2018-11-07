namespace Exercicio6
{
    /// <summary>
    /// A gun clip, which is a weapon decorator.
    /// </summary>
    public class GunClip : GunDecorator
    {
        /// <summary>
        /// The gun clip decorator increases the ammo capacity of a gun.
        /// </summary>
        public override int AmmoCapacity
        {
            get
            {
                return DecoratedGun.AmmoCapacity + extraCapacity;
            }
        }

        /// <summary>
        /// Extra capacity this decorator provides.
        /// </summary>
        private readonly int extraCapacity;

        /// <summary>
        /// Creates a new instance of a gun clip decorator.
        /// </summary>
        /// <param name="gun">
        /// The gun to decorate. This parameter is passed to the base class
        /// constructor.
        /// </param>
        /// <param name="extraCapacity">
        /// The extra ammo capacity this decorator provices.
        /// </param>
        public GunClip(Gun gun, int extraCapacity) : base(gun)
        {
            this.extraCapacity = extraCapacity;
        }

        /// <summary>
        /// Returns a rendering of the decorated gun with an extra clip.
        /// </summary>
        /// <returns>
        /// A rendering of the decorated gun with an extra clip.
        /// </returns>
        public override string GetRender()
        {
            // We cheat, since we only return a string and not a real 3D model
            return DecoratedGun.GetRender() + " + mag clip";
        }
    }
}
