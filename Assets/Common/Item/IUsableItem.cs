using Common.Inventory;

namespace Common.Item
{
    public interface IUsableItem : IItem
    {
        void Use();
    }
}