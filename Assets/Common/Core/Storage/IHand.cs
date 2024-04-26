using Common.Util;

namespace Common.Storage
{
    public interface IHand : IUnityObject
    {
        ItemData GetItem();
        void TakeItem(ItemData item);
    }
}