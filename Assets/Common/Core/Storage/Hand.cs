using UnityEngine;

namespace Common.Storage
{
    public class Hand : MonoBehaviour, IHand
    {
        private ItemData _itemInHand;
        
        public ItemData GetItem()
        {
            return _itemInHand;
        }

        public void TakeItem(ItemData item)
        {
            _itemInHand = item;
            
            var itemTransform = item.Item.transform;
            itemTransform.SetParent(transform);
            itemTransform.gameObject.SetActive(true);
            itemTransform.position = transform.position;
            itemTransform.rotation = transform.rotation;
            
            itemTransform.GetComponent<Rigidbody>().useGravity = false;
            itemTransform.GetComponent<Collider>().enabled = false;
        }
    }
}