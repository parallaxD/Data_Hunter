using Common.Core.Interactable.Item;
using Common.Core.Interactable.Item.Active;
using Common.Core.Storage;
using UnityEngine;

namespace Common.Game.Items.Weapon
{
    public class Gun : GameItem, IActiveItem
    {
        [SerializeField] private ShootController shootController;

        public void SetActive(bool isActive)
        {
            shootController.enabled = isActive;
        }

        public void SetHand(IHand hand)
        {
            shootController.WhoShoot = hand.GetInteractionPosition();
        }
    }
}