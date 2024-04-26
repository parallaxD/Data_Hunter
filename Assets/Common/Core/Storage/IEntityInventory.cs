using System;

namespace Common.Storage
{
    public interface IEntityInventory : IInventory
    {
        event Action<ItemData> SelectedSlotChanged;
        
        void SetSelected(int slot);
        int GetSelectedSlot();
        ItemData GetSelected();
    }
}