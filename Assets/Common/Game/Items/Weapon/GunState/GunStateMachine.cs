using Common.Core.State;

namespace Common.Game.Items.Weapon.GunState
{
    public class GunStateMachine : StateMachine
    {
        public GunStateMachine(ShootController controller, int shootingDelayMs, bool hasAutomaticShooting, int reloadDelayMs)
        {
            AddState(new ShootingState(controller, this, shootingDelayMs, hasAutomaticShooting));
            AddState(new ReloadState(controller, this, reloadDelayMs));
            AddState(new ReadyToShootState(controller, this));
            SetState<ReadyToShootState>();
        }
    }
}