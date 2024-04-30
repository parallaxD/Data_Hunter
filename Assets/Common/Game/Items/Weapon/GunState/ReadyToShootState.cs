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
            if (Input.GetMouseButtonDown(0))
            {
                StateMachine.SetState<ShootingState>();
                return;
            }

            if (!Input.GetKeyUp(KeyCode.R)) 
                return;

            StateMachine.SetState<ReloadState>();
        }
    }
}