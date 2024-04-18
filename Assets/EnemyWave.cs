using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] private List<EnemySpawnPoint> _enemySpawnPoints;
    [SerializeField] private EnemySpawnManager _enemySpawnManager;

    // ”словие спавна волны

    private void Start()
    {
        foreach (var component in GetComponentsInChildren<EnemySpawnPoint>())
        {
            AddEnemyToWave(component);
        }
        SpawnEnemyWave();
    }

    // —юда можно будет добавить любое условие дл€ спавна любой волны противников
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
