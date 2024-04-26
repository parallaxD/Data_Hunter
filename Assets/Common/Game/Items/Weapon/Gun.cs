using Common.Interactable.Item;
using UnityEngine;

namespace Common.Game.Items.Weapon
{
    public class Gun : UsableItem
    {

        [SerializeField] private ShootController shootController;
        
        public override void Use(ActionType type)
        {
            if (type == ActionType.General) 
                shootController.Shoot();
            else
                shootController.Reload();
        }
        
        

    }
}