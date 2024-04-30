
using UnityEngine;

namespace Common.Core.Interactable.Item.Usable
{
    public abstract class UsableItem : GameItem, IUsableItem
    {
        public abstract void Use(GameObject who, ActionType type);
    }
}