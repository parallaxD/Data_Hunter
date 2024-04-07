using System;
using Common.Interactable.Item;
using Common.Item;

namespace Common.Inventory
{
    public class ItemData
    {
        private int _amount;
        
        public int Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                Inventory?.MarkChanged(this);
            }
        }

        public ItemType Type { get; }
        public IInventory Inventory { get; }

        public ItemData(IItem reference, IInventory inventory)
        {
            Amount = reference.GetAmount();
            Type = reference.GetItemType();
            Inventory = inventory;
        }
        
    }
}