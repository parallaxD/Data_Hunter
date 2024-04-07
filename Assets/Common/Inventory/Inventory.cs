using System;
using System.Collections.Generic;
using Common.Interactable.Item;
using Common.Item;
using UnityEngine;

namespace Common.Inventory
{
    public class Inventory : MonoBehaviour, IInventory
    {
        [SerializeField] [Range(1, 1000)] private int size = 1; 
        
        public event Action<ItemData> ItemAdded;
        public event Action<ItemData> ItemChanged;
        public event Action<ItemData> ItemRemoved;
        
        private readonly List<ItemData> _slots = new ();

        public List<ItemData> GetAll()
        {
            return new List<ItemData>(_slots);
        }

        public ItemData Get(int slot)
        {
            return _slots[slot];
        }

        public int AddToSlot(IItem item)
        {
            CheckInventoryIsFull();
            
            var itemData = new ItemData(item, this);
            _slots.Add(itemData);
            
            ItemAdded?.Invoke(itemData);
            return _slots.Count - 1;
        }

        public void AddToSlot(IItem item, int slot)
        {
            CheckInventoryIsFull();
            
            var itemData = new ItemData(item, this);
            _slots[slot] = itemData;
            ItemAdded?.Invoke(itemData);
        }

        public void Remove(int slot)
        {
            var itemData = _slots[slot];
            
            _slots.RemoveAt(slot);
            ItemRemoved?.Invoke(itemData);
        }

        public int GetSize()
        {
            return _slots.Count;
        }

        public void MarkChanged(ItemData item)
        {
            ItemChanged?.Invoke(item);
        }

        private void CheckInventoryIsFull()
        {
            if (_slots.Count >= size)
                throw new IndexOutOfRangeException("Inventory is full");
        }
    }
}