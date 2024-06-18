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

        private void Start()
        {
            var damageableImpl = damageable.Value;
            damageableImpl.OnDamage += changer =>
            {
                OnHealthChanged?.Invoke(damageableImpl.GetHp(), damageableImpl.GetMaxHp());
                Debug.Log("Игрок получил урон, hp = " + damageableImpl.GetHp());
            }; 
            damageableImpl.OnHeal += changer =>
            {
                OnHealthChanged?.Invoke(damageableImpl.GetHp(), damageableImpl.GetMaxHp());
                Debug.Log("Игрок хиляется, hp = " + damageableImpl.GetHp());
            }; 
        }
    }
}

