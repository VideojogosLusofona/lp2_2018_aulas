using System;

namespace Exercicio6
{
    /// <summary>
    /// Our abstract Gun class declares the properties and methods of a gun.
    /// </summary>
    public abstract class Gun
    {

        /// <summary>
        /// The ammo capacity for the gun, defined by subclasses.
        /// </summary>
        public abstract int AmmoCapacity { get; }

        /// <summary>
        /// The noise level for the gun, defined by subclasses.
        /// </summary>
        public abstract float NoiseLevel { get; }

        /// <summary>
        /// Fire the gun. This is an example of polymorphism, since this
        /// method uses properties and methods which will only be defined by
        /// subclasses.
        /// </summary>
        public void Fire()
        {
            Console.WriteLine($"Fired a {GetRender()}" +
                $" with a noise level of {NoiseLevel}Db and capacity for" +
                $" {AmmoCapacity} rounds");
        }

        /// <summary>
        /// Only concrete weapons know how to render themselves. As such this
        /// method must be abstract.
        /// </summary>
        /// <returns>A string representing the rendering of the gun.</returns>
        public abstract string GetRender();

    }
}
