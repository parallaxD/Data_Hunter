using System;
using System.Threading;
using Common.Core.State;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.Game.Items.Weapon.GunState
{
    public class ShootingState : GunState
    {
        private bool _hasAutomaticShooting = false;
        private int _shootingDelay = 0;
        
        private AsyncLazy _shootDelayTask = UniTask.CompletedTask.ToAsyncLazy();

        public ShootingState(ShootController shootController, StateMachine stateMachine, int shootingDelayMs, bool hasAutomaticShooting)
            : base(shootController, stateMachine)
        {
            _hasAutomaticShooting = hasAutomaticShooting;
            _shootingDelay = shootingDelayMs;
        }
        
        public override async void Apply()
        {
            if (!_shootDelayTask.Task.Status.IsCompleted())
                return;
            
            ShootController.Shoot();
            ShootController.NeedShoot = false;
            ShootController.NeedReload = false;
            
            _shootDelayTask = UniTask.Delay(TimeSpan.FromMilliseconds(_shootingDelay), DelayType.DeltaTime, PlayerLoopTiming.Update, Application.exitCancellationToken).ToAsyncLazy();
            await _shootDelayTask.Task;
            
            if (!(_hasAutomaticShooting && (ShootController.NeedShoot || Input.GetMouseButton(0) && ShootController.WhoShoot.CompareTag("MainCamera"))))
                StateMachine.SetState<ReadyToShootState>();
        }
    }
}