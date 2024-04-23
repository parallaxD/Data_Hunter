using System;
using Common.Storage;
using UnityEngine;

namespace Common.Player
{
    public class PlayerInventoryController : MonoBehaviour
    {
        //TODO: понять как поменять на IHand
        [SerializeField, SerializeReference] private Hand playerHand;
        private IEntityInventory _inventory;

        private void Start()
        {
            _inventory = GetComponent<IEntityInventory>();
            _inventory.ItemAdded += TakeFirstPickedItem();
        }

        private void Update()
        {
            HandleSelectInventorySlot();
        }

        private void HandleSelectInventorySlot()
        {
            if (Input.GetAxis("Mouse ScrollWheel") == 0)
                return;

            TakeNextItemToHand();
        }

        private void TakeNextItemToHand()
        {
            var itemInHand = playerHand.GetItem();
            if (itemInHand != null)
            {
                itemInHand.Item.transform.SetParent(itemInHand.Inventory.transform);
                itemInHand.Item.gameObject.SetActive(false);
            }

            var nextSlot = _inventory.GetSelectedSlot() + ScrollWell;
            _inventory.SetSelected(nextSlot);

            var item = _inventory.GetSelected();
            playerHand.TakeItem(item);
        }
        
        private Action<ItemData> TakeFirstPickedItem()
        {
            return item =>
            {
                if (item.Inventory?.GetSize() == 1)
                    TakeNextItemToHand();
            };
        }
        
        private int ScrollWell => Mathf.FloorToInt(Input.GetAxis("Mouse ScrollWheel") * 10);
    }
}