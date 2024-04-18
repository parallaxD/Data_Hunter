using Common.Storage;
using UnityEngine;

namespace Common.Player
{
    public class PlayerInventoryController : MonoBehaviour
    {
        //TODO: понять как поменять на IHand
        [SerializeField, SerializeReference] private Hand _playerHand;
        private IEntityInventory _inventory;

        private void Start()
        {
            _inventory = GetComponent<IEntityInventory>();
        }

        private void Update()
        {
            HandleSelectInventorySlot();
        }

        private void HandleSelectInventorySlot()
        {
            if (Input.GetAxis("Mouse ScrollWheel") == 0)
                return;

            var itemInHand = _playerHand.GetItem();
            if (itemInHand != null)
            {
                itemInHand.Item.transform.SetParent(itemInHand.Inventory.transform);
                itemInHand.Item.gameObject.SetActive(false);
            }

            var nextSlot = _inventory.GetSelectedSlot() + ScrollWell;
            _inventory.SetSelected(nextSlot);

            var item = _inventory.GetSelected();
            _playerHand.TakeItem(item);
        }

        private int ScrollWell => Mathf.FloorToInt(Input.GetAxis("Mouse ScrollWheel") * 10);
    }
}