using UnityEngine;

namespace Common.Core.Interactable.Item.Usable
{
    public interface IUsableItem : IItem
    {
        void Use(GameObject who, ActionType type);
    }
}