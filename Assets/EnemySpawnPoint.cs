using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public Vector3 Position;
    public GameObject EnemyToSpawn;

    private void Awake()
    {
        Position = gameObject.transform.position;
        print(Position);
    }

}
