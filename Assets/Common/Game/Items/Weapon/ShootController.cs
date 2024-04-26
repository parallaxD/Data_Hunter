using Common.Animation;
using Common.Damage;
using Common.Interactable.Item.Weapon;
using TNRD;
using UnityEngine;

namespace Common.Game.Items.Weapon
{
    public class ShootController : MonoBehaviour
    {
        [SerializeField] protected int MaxAmmo = 12;
        [SerializeField] protected int AmmoCount = 0;
        [SerializeField] protected SerializableInterface<IAnimator> shootAnimation;
        [SerializeField] protected SerializableInterface<IAnimator> reloadAnimation;

        public void Shoot(GameObject who)
        {
            TryApplyRaycastDamage(who.transform);
            RunShootAnimation();
            if (AmmoCount == 0)
                Reload();
        }

        public void Reload()
        {
            RunReloadAnimation();
        }

        private void Start()
        {
            AmmoCount = MaxAmmo;
        }

        private void TryApplyRaycastDamage(Transform shootPoint)
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

        private IHpChanger GetDamageProvider(IDamageable damageable)
        {
            return new GunDamageProvider(20);
        }

        private void RunShootAnimation()
        {
            shootAnimation.Value.RunAnimation();
        }

        private void RunReloadAnimation()
        {
            reloadAnimation.Value.RunAnimation();
        }
    }
}