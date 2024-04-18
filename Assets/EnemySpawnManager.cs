using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour, ISpawnHandler
{
    public void SpawnEnemy(EnemySpawnPoint spawnPoint)
    {
        Instantiate(spawnPoint.EnemyToSpawn, spawnPoint.Position, Quaternion.identity);
    }
}
