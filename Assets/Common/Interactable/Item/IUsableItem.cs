using Common.Item;

namespace Common.Interactable.Item
{
    public interface IUsableItem : IItem
    {
        void Use();
    }
}