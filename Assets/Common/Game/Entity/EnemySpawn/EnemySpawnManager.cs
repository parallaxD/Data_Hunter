using UnityEngine;

namespace Common.GameEntity.EnemySpawn
{
    public class EnemySpawnManager : MonoBehaviour, ISpawnHandler
    {
        public void SpawnEnemy(EnemySpawnPoint spawnPoint)
        {
            Instantiate(spawnPoint.EnemyToSpawn, spawnPoint.Position, Quaternion.identity);
        }
    }
}
