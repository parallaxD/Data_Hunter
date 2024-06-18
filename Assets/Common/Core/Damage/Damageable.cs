using System;
using Common.Damage;
using UnityEngine;

namespace Common.Core.Damage
{
    public class Damageable : MonoBehaviour, IDamageable
    {
        public event Action<IHpChanger> OnDamage;
        public event Action<IHpChanger> OnHeal;
        public event Action<IDamageable> OnDestroy;

        [SerializeField] private int hp; 
        [SerializeField] private int maxHp; 
        
        public void Apply(IHpChanger hpChanger)
        {
            var currentHp = hp;
            hp += hpChanger.CalculateHpDiff();

            var hpEvent = hp > currentHp
                ? OnHeal
                : OnDamage;
            hpEvent?.Invoke(hpChanger);
            
            if (hp <= 0)
            {
                OnDestroy?.Invoke(this);
                return;
            }

            if (hp > maxHp)
                hp = maxHp;
        }

        public int GetHp()
        {
            return hp;
        }

        public int GetMaxHp()
        {
            return maxHp;
        }
    }
}