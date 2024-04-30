using System;
using Common.Core.Storage;

namespace Common.Storage
{
    public class EntityInventory : Inventory, IEntityInventory
    {
        private int _selectedSlot = 0;

        public event Action<ItemData> SelectedSlotChanged;

        public void SetSelected(int slot)
        {
            if (slot >= Slots.Count)
                slot = 0;
            else if (slot < 0)
                slot = Slots.Count - 1; 
            
            _selectedSlot = slot;
            SelectedSlotChanged?.Invoke(Slots[_selectedSlot]);
        }

        public ItemData GetSelected()
        {
            return _itemCount == 0 ? null : Slots[_selectedSlot];
        }

        public int GetSelectedSlot()
        {
            return _selectedSlot;
        }
    }
}