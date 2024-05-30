using System.Collections.Generic;
using Common.Storage;
using UnityEngine;

namespace Common.Game.Entity.Enemy
{
    public class EnemyInventory : EntityInventory
    {
        [SerializeField] private List<GameObject> startedItems = new ();

        private void Start()
        {
            
        }
    }
}