using System;
using System.Collections.Generic;
using Common.GameEntity.EnemySpawn;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.Game.Entity.EnemySpawn
{
    public class EnemyWaveStarter : MonoBehaviour
    {
        [SerializeField] private List<Game.Entity.Objects.Door> _doors;
        [SerializeField] private EnemyWave _wave;
        private int countWaves = 1;
        private bool needSpawn = true;

        private void Start()
        {
            _wave.SpawnEnemyWave();
        }

        /*public async void StartWave()
        {
            countWaves--;
            needSpawn = false;
            _doors.ForEach(d => d.OpenDoor());
            _wave.SpawnEnemyWave();
            
            var closeTask = UniTask.Delay(TimeSpan.FromSeconds(10), DelayType.UnscaledDeltaTime, PlayerLoopTiming.FixedUpdate, Application.exitCancellationToken).ToAsyncLazy();
            await closeTask.Task;
            
            _doors.ForEach(d => d.CloseDoor());
            
            var nextWaveTask = UniTask.Delay(TimeSpan.FromSeconds(120), DelayType.UnscaledDeltaTime, PlayerLoopTiming.FixedUpdate, Application.exitCancellationToken).ToAsyncLazy();
            await nextWaveTask.Task;
            needSpawn = true;
        }*/
    }
}