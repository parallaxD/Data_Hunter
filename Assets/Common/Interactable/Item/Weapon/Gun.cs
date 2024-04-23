using Common.Animation;
using Common.Damage;
using TNRD;
using UnityEngine;

namespace Common.Interactable.Item.Weapon
{
    public class Gun : UsableItem
    {
        [SerializeField] protected Transform shootPoint;
        [SerializeField] protected SerializableInterface<IAnimator> animator;

        private void Update()
        {
            var ray = new Ray(shootPoint.position, shootPoint.forward);
            Debug.DrawRay(ray.origin, ray.direction);
        }

        public override void Use()
        {
            TryApplyRaycastDamage();
            animator.Value?.RunAnimation();
        }

        private void TryApplyRaycastDamage()
        {
            var ray = new Ray(shootPoint.position, shootPoint.forward);
            Debug.DrawRay(ray.origin, ray.direction);
            if (!Physics.Raycast(ray, out var hit))
                return;

            var hasDamageable = hit.transform.TryGetComponent(out IDamageable damageable);
            if (!hasDamageable)
                return;
            
            damageable.Apply(GetDamageProvider(damageable));
        }

        protected virtual IHpChanger GetDamageProvider(IDamageable damageable)
        {
            return new GunDamageProvider(20);
        }
    }
}