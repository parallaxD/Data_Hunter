using Common.Core.State;
using UnityEngine;
using Input = UnityEngine.Input;

namespace Common.Game.Items.Weapon.GunState
{
    public class ReadyToShootState : GunState
    {
        public ReadyToShootState(ShootController shootController, StateMachine stateMachine) 
            : base(shootController, stateMachine) { }

        public override void Apply()
        {
            if (ShootController.NeedShoot || Input.GetMouseButtonDown(0) && ShootController.WhoShoot.CompareTag("MainCamera"))
            {
                StateMachine.SetState<ShootingState>();
                return;
            }

            if (!ShootController.NeedReload || Input.GetKeyUp(KeyCode.R) && ShootController.WhoShoot.CompareTag("MainCamera")) 
                return;

            StateMachine.SetState<ReloadState>();
        }
    }
}