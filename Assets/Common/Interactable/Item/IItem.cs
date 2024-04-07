using System;
using Common.Item;

namespace Common.Interactable.Item
{
    public interface IItem : IInteractable
    {
        int GetAmount();
        ItemType GetItemType();
        event Action Changed;
    }
}