namespace Exercicio6
{
    /// <summary>
    /// Abstract class which defines a gun decorator.
    /// </summary>
    public abstract class GunDecorator : Gun
    {
        /// <summary>
        /// The gun this decorator decorates.
        /// </summary>
        protected Gun DecoratedGun { get; }

        /// <summary>
        /// By default, decorators don't change the ammo capacity, unless
        /// subclasses explicitly override this method.
        /// </summary>
        public override int AmmoCapacity
        {
            get
            {
                return DecoratedGun.AmmoCapacity;
            }
        }

        /// <summary>
        /// By default, decorators don't change the noise level, unless
        /// subclasses explicitly override this method.
        /// </summary>
        public override float NoiseLevel
        {
            get
            {
                return DecoratedGun.NoiseLevel;
            }
        }

        /// <summary>
        /// This constructor will only be called by subclasses to set the
        /// decorated gun.
        /// </summary>
        /// <param name="gun">The gun to decorate.</param>
        protected GunDecorator(Gun gun)
        {
            DecoratedGun = gun;
        }
    }
}
