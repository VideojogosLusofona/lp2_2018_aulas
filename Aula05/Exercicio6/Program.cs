using System;

namespace Exercicio6
{
    /// <summary>
    /// This class tests our decorated guns class design.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Program starts here.
        /// </summary>
        static void Main()
        {
            // Local variables for a machine gun and a shotgun
            Gun machineGun;
            Gun shotGun;

            // Create a machine gun decorated with a clip and a silencer
            machineGun = new MachineGun(120, 30);
            machineGun = new GunSilencer(machineGun, 0.6f);
            machineGun = new GunClip(machineGun, 30);

            // Fire the decorated machine gun and see how it renders
            Console.WriteLine("=== Machine gun ===");
            machineGun.Fire();
            Console.WriteLine(machineGun.GetRender());
            Console.WriteLine();

            // Create a shotgun with two clips
            shotGun = new ShotGun(6, 50);
            shotGun = new GunClip(shotGun, 2);
            shotGun = new GunClip(shotGun, 2);

            // Fire the decorated shotgun and see how it renders
            Console.WriteLine("n=== Shotgun ===");
            shotGun.Fire();
            Console.WriteLine(shotGun.GetRender());
            Console.WriteLine();

        }
    }
}
