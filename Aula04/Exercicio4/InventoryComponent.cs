using System;

namespace Aula04
{
    public abstract class InventoryComponent
        : IComponent<InventoryComponent>, IHasWeight
    {
        // Subclasses decide how to implement the Weight property
        public abstract float Weight { get; }

        // The item management methods are defined here but by default throw
        // an exception when invoked. This follows the uniformity approach in
        // the composite pattern.

        public virtual void Add(InventoryComponent child)
        {
            throw new NotImplementedException();
        }

        public virtual InventoryComponent GetChild(int i)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(InventoryComponent child)
        {
            throw new NotImplementedException();
        }
    }
}
