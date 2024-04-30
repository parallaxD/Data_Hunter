using Common.Storage;
using Common.Util;
using UnityEngine;

namespace Common.Core.Storage
{
    public interface IHand : IUnityObject
    {
        ItemData GetItem();
        void TakeItem(ItemData item);
        Transform GetInteractionPosition();
    }
}