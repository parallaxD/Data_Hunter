using Common.Damage;
using UnityEngine;

namespace Common.Entity
{
    public class Enemy : MonoBehaviour
    {
        private IDamageable _damageable;

        private void Start()
        {
            _damageable = GetComponent<IDamageable>();
            _damageable.OnDestroy += d => Destroy(gameObject);
        }
    }
}