using System.Collections.Generic;

namespace Common.Inventory
{
    public interface IInventory
    {
        void put(IItem item);
        void put(IItem item, int index);
        void remove(int index);
        List<IItem> getItems();
        int getSize();
    }
}