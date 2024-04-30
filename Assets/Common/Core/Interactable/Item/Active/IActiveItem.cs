using Common.Core.Storage;

namespace Common.Core.Interactable.Item.Active
{
    public interface IActiveItem : IItem
    {
        void SetActive(bool isActive);
        void SetHand(IHand hand);
    }
}