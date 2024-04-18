using System;
using System.Collections.Generic;
using Common.Interactable.Item;
using UnityEngine;

namespace Common.Storage
{
    public class Inventory : MonoBehaviour, IInventory
    {
        [SerializeField] [Range(1, 100)] protected int size = 1; 
        
        public event Action<ItemData> ItemAdded;
        public event Action<ItemData> ItemChanged;
        public event Action<ItemData> ItemRemoved;
        
        protected readonly List<ItemData> Slots = new ();

        protected GameObject ItemStore;
        
        private void Start()
        {
            InitializeItemStore();
        }

        public List<ItemData> GetAll()
        {
            return new List<ItemData>(Slots);
        }

        public ItemData Get(int slot)
        {
            return Slots[slot];
        }

        public int AddToSlot(IItem item)
        {
            CheckInventoryIsFull();
            
            var itemData = new ItemData(item, this);
            Slots.Add(itemData);
            PutItemToItemStore(item);
            
            ItemAdded?.Invoke(itemData);
            return Slots.Count - 1;
        }

        public void AddToSlot(IItem item, int slot)
        {
            CheckInventoryIsFull();
            
            var itemData = new ItemData(item, this);
            Slots[slot] = itemData;
            PutItemToItemStore(item);
            
            ItemAdded?.Invoke(itemData);
        }

        public void Remove(int slot)
        {
            var itemData = Slots[slot];
            
            Slots.RemoveAt(slot);
            ItemRemoved?.Invoke(itemData);
        }

        public int GetSize()
        {
            return Slots.Count;
        }

        public void MarkChanged(ItemData item)
        {
            ItemChanged?.Invoke(item);
        }

        private void CheckInventoryIsFull()
        {
            if (Slots.Count >= size)
                throw new IndexOutOfRangeException("Inventory is full");
        }

        private void PutItemToItemStore(IItem item)
        {
            if (ItemStore == null)
                InitializeItemStore();
            
            item.transform.SetParent(ItemStore.transform);
            item.gameObject.SetActive(false);
        }

        private void InitializeItemStore()
        {
            ItemStore = new GameObject("ItemStore");
        }
    }
}