
using UnityEngine;

namespace Common.Interactable.Item
{
    public interface IUsableItem : IItem
    {
        void Use(GameObject who, ActionType type);
    }
}