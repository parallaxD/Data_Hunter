using Common.Inventory;
using Common.Item;
using UnityEngine;

namespace Common.Interactable.Item
{
    public class ItemInteractionHandler : IInteractionHandler
    {

        private GameObject _who;
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
            Object.Destroy(_item.gameObject);
        }
    }
}