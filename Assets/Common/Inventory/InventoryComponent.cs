using System.Collections.Generic;
using Common.Inventory;
using UnityEngine;

public class InventoryComponent : MonoBehaviour, IInventory
{
    private readonly List<IItem> store = new (); 

    public void put(IItem item)
    {
        store.Add(item);
    }

    public void put(IItem item, int index)
    {
        store[index] = item;
    }

    public void remove(int index)
    {
        store.RemoveAt(index);
    }

    public List<IItem> getItems()
    {
        return new List<IItem>(store);
    }

    public int getSize()
    {
        return store.Count;
    }
}
