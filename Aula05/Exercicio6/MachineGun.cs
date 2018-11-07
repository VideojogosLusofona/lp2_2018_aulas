namespace Exercicio6
{
    /// <summary>
    /// This class represents a machine gun, which is a concrete implementation
    /// of a gun.
    /// </summary>
    public class MachineGun : Gun
    {
        /// <summary>
        /// The ammo capacity for the machine gun.
        /// <see cref="Gun.AmmoCapacity"/>
        /// </summary>
        public override int AmmoCapacity { get { return ammoCapacity; } }

        /// <summary>
        /// The noise level for the machine gun.
        /// <see cref="Gun.NoiseLevel"/>
        /// </summary>
        public override float NoiseLevel { get { return noiseLevel; } }

        /// <summary>
        /// Support variable for the AmmoCapacity property.
        /// </summary>
        private readonly int ammoCapacity;

        /// <summary>
        /// Support variable for the NoiseLevel property.
        /// </summary>
        private readonly float noiseLevel;

        /// <summary>
        /// Create a new machine gun with the specified ammo capacity and
        /// noise level.
        /// </summary>
        /// <param name="ammoCapacity">
        /// The ammo capacity for the machine gun.
        /// </param>
        /// <param name="noiseLevel">
        /// The noise level for the machine gun.
        /// </param>
        public MachineGun(int ammoCapacity, float noiseLevel)
        {
            this.ammoCapacity = ammoCapacity;
            this.noiseLevel = noiseLevel;
        }

        /// <summary>
        /// Return a rendering of the machine gun.
        /// </summary>
        /// <returns>A rendering of the machine gun.</returns>
        public override string GetRender()
        {
            // We cheat, since we only return a string and not a real 3D model
            return "Machine Gun";
        }
    }
}
