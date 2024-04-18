using Common.Item;
using Common.Storage;
using UnityEngine;

namespace Common.Interactable.Item
{
    public class ItemInteractionHandler : IInteractionHandler
    {
        private readonly GameObject _who;
        private readonly Item _item;

        public ItemInteractionHandler(GameObject who, Item item)
        {
            _who = who;
            _item = item;
        }

        public void Interact()
        {
            var hasInventory = _who.TryGetComponent(out IInventory inventory);
            if(!hasInventory)
                return;

            inventory.AddToSlot(_item);
        }
    }
}