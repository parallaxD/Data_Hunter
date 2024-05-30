using System.Collections.Generic;
using UnityEngine;

namespace Common.GameEntity.EnemySpawn
{
    public class EnemyWave : MonoBehaviour
    {
        [SerializeField] private List<EnemySpawnPoint> _enemySpawnPoints;
        [SerializeField] private EnemySpawnManager _enemySpawnManager;

        // Условие спавна волны

        private void Start()
        {
            foreach (var component in GetComponentsInChildren<EnemySpawnPoint>())
            {
                AddEnemyToWave(component);
            }
            SpawnEnemyWave();
        }

        // Сюда можно будет добавить любое условие для спавна любой волны противников
        // if (condition) { SpawnEnemyWave() }
        private void SpawnEnemyWave()
        {
            foreach(var spawnPoint in _enemySpawnPoints)
            {
                _enemySpawnManager.SpawnEnemy(spawnPoint);
            }
        }

        private void AddEnemyToWave(EnemySpawnPoint spawnPoint)
        {
            _enemySpawnPoints.Add(spawnPoint);
        }
    }
}
