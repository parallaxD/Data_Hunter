using UnityEngine;

namespace Common.GameEntity.EnemySpawn
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        public Vector3 Position;
        public GameObject EnemyToSpawn;

        private void Awake()
        {
            Position = gameObject.transform.position;
            // print(Position);
        }

    }
}
