using Common.Core.Interactable.Item;
using Common.Storage;

namespace Common.Core.Storage
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