using Common.Core.Storage;
using Common.Item;
using Common.Storage;
using UnityEngine;

namespace Common.Core.Interactable.Item
{
    public class ItemInteractionHandler : IInteractionHandler
    {
        private readonly GameObject _who;
        private readonly GameItem _gameItem;

        public ItemInteractionHandler(GameObject who, GameItem gameItem)
        {
            _who = who;
            _gameItem = gameItem;
        }

        public void Interact()
        {
            var hasInventory = _who.TryGetComponent(out IInventory inventory);
            if(!hasInventory)
                return;

            inventory.AddToSlot(_gameItem);
        }
    }
}