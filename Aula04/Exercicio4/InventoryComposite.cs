using System.Collections.Generic;

namespace Aula04
{
    public class InventoryComposite : InventoryComponent
    {
        // The weight is equal to the weight of all child components
        public override float Weight {
            get
            {
                float totWeight = 0;
                foreach (InventoryComponent child in children)
                {
                    totWeight += child.Weight;
                }
                return totWeight;
            }
        }

        // A list containing all child components in this composite component
        private readonly List<InventoryComponent> children;

        // The constructor instantiates the list of children.
        public InventoryComposite()
        {
            children = new List<InventoryComponent>();
        }

        // Below are working overrides of the item management methods.
        // The simply delegate their behaviour to the list of children.

        public override void Add(InventoryComponent child)
        {
            children.Add(child);
        }

        public override InventoryComponent GetChild(int i)
        {
            return children[i];
        }

        public override void Remove(InventoryComponent child)
        {
            children.Remove(child);
        }

    }
}
