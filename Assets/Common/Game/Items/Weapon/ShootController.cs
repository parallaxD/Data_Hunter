using Common.Animation;
using Common.Core.State;
using Common.Damage;
using Common.Game.Items.Weapon.GunState;
using TNRD;
using UnityEngine;
using UnityEngine.Serialization;

namespace Common.Game.Items.Weapon
{
    public class ShootController : MonoBehaviour
    {
        [Header("Gun settings")]
        [SerializeField] protected int MaxAmmo = 12;
        [SerializeField] protected int AmmoCount = 0;
        [SerializeField] protected int shootingDelayMs = 2;
        [SerializeField] protected int reloadDelayMs = 2;
        [SerializeField] protected bool automaticShooting = false;
        
        public Transform WhoShoot { get; set; }

        [Header("Animation")]
        [SerializeField] protected SerializableInterface<IAnimator> shootAnimation;
        [SerializeField] protected SerializableInterface<IAnimator> reloadAnimation;
        private StateMachine _shootState;

        public bool NeedReload { get; set; }
        public bool NeedShoot { get; set; }

        private void Start()
        {
            AmmoCount = MaxAmmo;
            _shootState = new GunStateMachine(this, shootingDelayMs, automaticShooting, reloadDelayMs);
            enabled = false;
        }

        private void Update()
        {
            _shootState?.Update();   
        }

        public void Shoot()
        {
            TryApplyRaycastDamage(WhoShoot);
            RunShootAnimation();
            if (AmmoCount == 0)
                Reload();
        }
        
        public void Reload()
        {
            RunReloadAnimation();
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
            AmmoCount--;
        }

        protected virtual IHpChanger GetDamageProvider(IDamageable damageable)
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