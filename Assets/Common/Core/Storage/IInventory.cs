using System;
using System.Collections.Generic;
using Common.Interactable.Item;
using Common.Util;

namespace Common.Storage
{
    public interface IInventory : IUnityObject
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

        int GetItemCount();
        
        void MarkChanged(ItemData item);
    }
}