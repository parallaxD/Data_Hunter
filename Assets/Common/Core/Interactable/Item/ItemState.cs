using System;
using Common.Core.Interactable.Item.Active;
using Common.Core.Storage;
using UnityEngine;

namespace Common.Core.Interactable.Item
{
    public abstract class ItemState
    {
        public static readonly ItemState InInventory = new InInventoryState(); 
        public static readonly Func<IHand, ItemState> InHand = hand => new InHandState(hand); 
        public static readonly ItemState OnGround = new OnGroundState(); 
        public abstract void Apply(IItem item);
        
        private class InInventoryState : ItemState
        {
            public override void Apply(IItem item)
            {
                item.gameObject.SetActive(false);
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ItemState)obj);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode();
        }

        private class InHandState : ItemState
        {
            private readonly IHand _hand;
            
            public InHandState(IHand hand)
            {
                _hand = hand;
            }
            
            public override void Apply(IItem item)
            {
                var transform = item.transform;
                
                item.gameObject.SetActive(true);
                
                transform.TryGetComponent<Rigidbody>(out var rigidbodyComponent);
                rigidbodyComponent.useGravity = false;
            
                transform.TryGetComponent<Collider>(out var colliderComponent);
                colliderComponent.enabled = false;
                
                transform.TryGetComponent<IActiveItem>(out var activeItemComponent);
                activeItemComponent.SetActive(true);
                activeItemComponent.SetHand(_hand);
            }
        }

        private class OnGroundState : ItemState
        {
            public override void Apply(IItem item)
            {
                var transform = item.transform;
                
                item.gameObject.SetActive(true);
                
                transform.TryGetComponent<Rigidbody>(out var rigidbodyComponent);
                rigidbodyComponent.useGravity = true;
            
                transform.TryGetComponent<Collider>(out var colliderComponent);
                colliderComponent.enabled = true;
                
                transform.TryGetComponent<IActiveItem>(out var activeItemComponent);
                activeItemComponent.SetActive(false);
            }
        }
    }
}