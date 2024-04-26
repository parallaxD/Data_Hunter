
using Common.Interactable.Item;
using UnityEngine;

namespace Common.Core.Interactable.Item.Usable
{
    public abstract class UsableItem : Common.Interactable.Item.Item, IUsableItem
    {
        public abstract void Use(GameObject who, ActionType type);
    }
}