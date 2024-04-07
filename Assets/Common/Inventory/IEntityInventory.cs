namespace Common.Inventory
{
    public interface IEntityInventory : IInventory
    {
        void SetSelected(int slot);
        ItemData GetSelected();
    }
}