using UnityEngine;

namespace Common.Entity
{
    public class DamageComponent : MonoBehaviour, IDamageDealer
    {
        [Header("Damage")] 
        [SerializeField, Min(0)] private int damage = 20;
        [SerializeField] private LayerMask damageMask;
        [SerializeField, Min(0)] private float distance = 200f;
        [SerializeField, Min(0)] private int shootCount = 1;
        [SerializeField, Min(0)] private int spread = 0;
        
        public void PerformAttack()
        {
            for (var i = 0; i < shootCount; i++)
                ShootAndApplyDamage();
        }
        
        private void ShootAndApplyDamage()
        {
            var direction = CalculateShootDirection(transform.position);
            var ray = new Ray(transform.position, direction);

            if (!Physics.Raycast(ray, out var hit, distance, damageMask)) return;
            
            var hitCollider = hit.collider;
            if (hitCollider.TryGetComponent(out IDamageable damageable))
                damageable.applyDamage(damage);
        }

        private Vector3 CalculateShootDirection(Vector3 shootDirection)
        {
            return new Vector3
            {
                x = Random.Range(-spread, spread) + shootDirection.x,
                y = Random.Range(-spread, spread) + shootDirection.y,
                z = Random.Range(-spread, spread) + shootDirection.z
            };
        }
    }
}