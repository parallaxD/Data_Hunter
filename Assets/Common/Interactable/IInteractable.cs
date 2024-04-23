
using Common.Item;
using Common.Util;
using UnityEngine;

namespace Common.Interactable
{
    public interface IInteractable : IUnityObject
    {
        IInteractionHandler GetInteractionHandler(GameObject who);
    }
}