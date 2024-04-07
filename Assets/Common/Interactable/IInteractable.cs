
using UnityEngine;

namespace Common.Item
{
    public interface IInteractable
    {
        IInteractionHandler GetInteractionHandler(GameObject who);
    }
}