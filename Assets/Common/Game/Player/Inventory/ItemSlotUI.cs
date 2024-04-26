using System;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Game.Player.Inventory
{
    public class ItemSlotUI : MonoBehaviour
    {
        public Image Icon { get; set; }

        private void Start()
        {
            Icon = transform.GetChild(0).GetComponent<Image>();
        }
    }
}