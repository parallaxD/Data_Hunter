
namespace Common.Interactable.Item
{
    public abstract class UsableItem : Item, IUsableItem
    {
        public abstract void Use(ActionType type);
    }
}