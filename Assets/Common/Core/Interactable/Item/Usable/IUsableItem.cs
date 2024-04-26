
namespace Common.Interactable.Item
{
    public interface IUsableItem : IItem
    {
        void Use(ActionType type);
    }
}