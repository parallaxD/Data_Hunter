using Common.Core.State;

namespace Common.Game.Items.Weapon.GunState
{
    public abstract class GunState : State
    {
        protected readonly ShootController ShootController; 
        protected GunState(ShootController shootController, StateMachine stateMachine) : base(stateMachine)
        {
            ShootController = shootController;
        }
    }
}