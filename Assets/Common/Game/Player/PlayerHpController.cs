using Common.Damage;
using TNRD;
using UnityEngine;
using System;

namespace Common.Game.Player
{
    public class PlayerHpController : MonoBehaviour
    {
        [SerializeField] private SerializableInterface<IDamageable> damageable;
        public event Action<int, int> OnHealthChanged;

        private static readonly IHpChanger PlayerPassiveHeal = new PassiveHeal();
            
        private static readonly float TimeToHealWithoutDamage = 5;
        private static readonly float HealDelay = 0.3f;
        private float lastDamage = 0;
        private float lastHeal = 0;
        
        
        private void Start()
        {
            var damageableImpl = damageable.Value;
            damageableImpl.OnDamage += changer =>
            {
                OnHealthChanged?.Invoke(damageableImpl.GetHp(), damageableImpl.GetMaxHp());
                Debug.Log("Игрок получил урон, hp = " + damageableImpl.GetHp());
                lastDamage = 0;
            }; 
            damageableImpl.OnHeal += changer =>
            {
                OnHealthChanged?.Invoke(damageableImpl.GetHp(), damageableImpl.GetMaxHp());
                Debug.Log("Игрок хиляется, hp = " + damageableImpl.GetHp());
            }; 
        }

        private void FixedUpdate()
        {
            lastDamage += Time.fixedDeltaTime;
            lastHeal += Time.fixedDeltaTime;
            
            if (lastDamage >= TimeToHealWithoutDamage && lastHeal >= HealDelay)
            {
                damageable.Value.Apply(PlayerPassiveHeal);
                lastHeal = 0;
            }
        }
    }

    class PassiveHeal : IHpChanger
    {
        public int CalculateHpDiff()
        {
            return 6;
        }
    }
}

