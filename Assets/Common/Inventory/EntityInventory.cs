namespace Common.Inventory
{
    public class EntityInventory : Inventory, IEntityInventory
    {
        private int selectedSlot = 0;

        public void SetSelected(int slot)
        {
            selectedSlot = slot;
        }

        public ItemData GetSelected()
        {
            return Slots[selectedSlot];
        }
    }
}