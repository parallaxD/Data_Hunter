using Common.Interactable.Item;

namespace Common.Storage
{
    public class ItemData
    {
        public ItemType Type { get; }
        public IInventory Inventory { get; }

        public IItem Item { get; }
        
        public ItemData(IItem reference, IInventory inventory)
        {
            Type = reference.GetItemType();
            Inventory = inventory;
            Item = reference;
        }
    }
}