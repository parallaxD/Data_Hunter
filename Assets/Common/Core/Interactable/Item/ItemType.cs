using System;
using UnityEngine;

namespace Common.Interactable.Item
{
    [CreateAssetMenu(fileName = "ItemType", menuName = "Game/Items/New Item Type")]
    public class ItemType : ScriptableObject
    {
        [SerializeField] private string name;
        [SerializeField] private int minAmount = 1;
        [SerializeField] private int maxAmount = 1;
        [SerializeField] private Sprite itemIcon;

        public Guid Id { get; } = Guid.NewGuid();
        public string Name => name;
        public int MinAmount => minAmount;
        public int MaxAmount => maxAmount;
        public Sprite Icon => itemIcon;

        private bool Equals(ItemType other)
        {
            return base.Equals(other) && Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ItemType)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Id);
        }
    }
}