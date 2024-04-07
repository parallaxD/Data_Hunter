using System;
using System.Collections.Generic;
using Common.Interactable.Item;
using Common.Item;

namespace Common.Inventory
{
    public interface IInventory
    {
        event Action<ItemData> ItemAdded;
        event Action<ItemData> ItemChanged;
        event Action<ItemData> ItemRemoved;

        List<ItemData> GetAll();
        ItemData Get(int slot);
        
        int AddToSlot(IItem item);
        void AddToSlot(IItem item, int slot);
        
        void Remove(int slot);

        int GetSize();

        void MarkChanged(ItemData item);
    }
}