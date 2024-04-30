using System;
using Common.Item;
using UnityEngine;

namespace Common.Core.Interactable.Item
{
    public class GameItem : MonoBehaviour, IItem
    {
        [SerializeField] private ItemType type;
        [SerializeField] private int amount = 1;

        private int Amount
        {
            get => amount;
            set
            {
                amount = value > type.MaxAmount
                    ? type.MaxAmount
                    : value < type.MinAmount
                        ? type.MinAmount
                        : value;
                
                Changed?.Invoke();
            }
        }

        public int GetAmount() => Amount;

        public ItemType GetItemType() => type;
        public event Action Changed;
        
        public virtual void SetState(ItemState state)
        {
            state.Apply(this);
        }

        public IInteractionHandler GetInteractionHandler(GameObject who)
        {
            return new ItemInteractionHandler(who, this);
        }

        public Transform GetTransform()
        {
            return transform;
        }
    }
}