using Common.Storage;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Game.Player.Inventory
{
    public class PlayerInventoryDrawer : MonoBehaviour
    {
        [SerializeField] private EntityInventory entityInventory;
        [SerializeField] private ItemSlotUI[] slots;
        [SerializeField] private Image selectedMarker; 
        private void Update()
        {
            DrawInventory();
        }

        private void DrawInventory()
        {
            var items = entityInventory.GetAll();
            for (var i = 0; i < slots.Length; i++)
            {
                var itemSlot = slots[i];
                var slotIcon = itemSlot.Icon;
                if (i < items.Count)
                {   
                    var icon = items[i].Type.Icon;
                    slotIcon.sprite = icon;         
                    slotIcon.color = Color.white;
                }
                else
                {
                    slotIcon.sprite = null;
                    slotIcon.color = Color.clear;
                }

                if (i == entityInventory.GetSelectedSlot())
                    selectedMarker.rectTransform.position = slotIcon.rectTransform.position;
            }
        }
    }
}