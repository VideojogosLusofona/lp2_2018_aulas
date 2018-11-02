using System;

namespace Aula04
{
    class Program
    {
        static void Main(string[] args)
        {
            // Useful variables for creating components
            InventoryComponent ic1, ic2, ic3, icRoot;

            // Create a composite item and put two leaf items in it
            ic1 = new InventoryComposite();
            ic1.Add(new InventoryLeaf(10.5f));
            ic1.Add(new InventoryLeaf(13.1f));

            // Create another composite item and put the previous composite in
            // it plus another leaf
            ic2 = new InventoryComposite();
            ic2.Add(ic1);
            ic2.Add(new InventoryLeaf(4.8f));

            // Create yet another composite with four leaves
            ic3 = new InventoryComposite();
            ic3.Add(new InventoryLeaf(3.3f));
            ic3.Add(new InventoryLeaf(6.9f));
            ic3.Add(new InventoryLeaf(4.2f));
            ic3.Add(new InventoryLeaf(7.6f));

            // Create a final root composite, put ic2 and ic3 in it, plus
            // another two leaves
            icRoot = new InventoryComposite();
            icRoot.Add(ic2);
            icRoot.Add(ic3);
            icRoot.Add(new InventoryLeaf(11.1f));
            icRoot.Add(new InventoryLeaf(0.5f));

            // We can still add leaf items to our first composite. No problem,
            // it just works!
            ic1.Add(new InventoryLeaf(19.3f));

            // What is the weight of all this stuff? Easy, just get it from
            // the root of the tree:
            Console.WriteLine(icRoot.Weight);

        }
    }
}
