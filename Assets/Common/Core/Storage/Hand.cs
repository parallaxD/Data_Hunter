using Common.Core.Interactable.Item;
using Common.Core.Interactable.Item.Active;
using Common.Core.Storage;
using UnityEngine;

namespace Common.Storage
{
    public class Hand : MonoBehaviour, IHand
    {
        [SerializeField] private Transform interactionPosition; 
        private ItemData _itemInHand;

        public Transform InteractionPosition => interactionPosition;

        public ItemData GetItem()
        {
            return _itemInHand;
        }

        public void TakeItem(ItemData item)
        {
            _itemInHand = item;
            
            var itemTransform = item.Item.transform;
            itemTransform.SetParent(transform);
            itemTransform.position = transform.position;
            itemTransform.rotation = transform.rotation;
            
            item.Item.SetState(ItemState.InHand(this));
        }

        public Transform GetInteractionPosition()
        {
            return interactionPosition;
        }
    }
}