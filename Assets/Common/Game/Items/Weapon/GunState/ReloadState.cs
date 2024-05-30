using Common.Core.State;
using Cysharp.Threading.Tasks;

namespace Common.Game.Items.Weapon.GunState
{
    public class ReloadState : GunState
    {
        private UniTask _reloadTask = UniTask.CompletedTask;
        private readonly int _reloadDelay;

        public ReloadState(ShootController shootController, StateMachine stateMachine, int reloadDelay) : base(
            shootController, stateMachine)
        {
            _reloadDelay = reloadDelay;
        }

        public override async void Apply()
        {
            if (!_reloadTask.Status.IsCompleted())
                return;
            
            ShootController.Reload();
            
            _reloadTask = UniTask.Delay(_reloadDelay, DelayType.DeltaTime);
            await _reloadTask;
            
            StateMachine.SetState<ReadyToShootState>();
            ShootController.NeedShoot = false;
        }
    }
}