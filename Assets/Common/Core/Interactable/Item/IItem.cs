using System;

namespace Common.Core.Interactable.Item
{
    public interface IItem : IInteractable
    {
        int GetAmount();
        ItemType GetItemType();
        event Action Changed;
        void SetState(ItemState state);
    }
}