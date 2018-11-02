namespace Aula04
{
    public class InventoryLeaf : InventoryComponent
    {
        public override float Weight { get; }

        public InventoryLeaf(float weight)
        {
            Weight = weight;
        }
    }
}
