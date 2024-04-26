using Common.Core.Interactable.Item.Usable;
using Common.Interactable.Item;
using UnityEngine;

namespace Common.Game.Items.Weapon
{
    public class Gun : UsableItem
    {

        [SerializeField] private ShootController shootController;
        
        public override void Use(GameObject who, ActionType type)
        {
            if (type == ActionType.General) 
                shootController.Shoot(who);
            else
                shootController.Reload();
        }
    }
}