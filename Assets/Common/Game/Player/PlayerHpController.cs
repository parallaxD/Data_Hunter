using Common.Damage;
using TNRD;
using UnityEngine;
using System;

namespace Common.Game.Player
{
    public class PlayerHpController : MonoBehaviour
    {
        [SerializeField] private SerializableInterface<IDamageable> damageable;

        private int _currentHP;

        public event Action<int> OnHealthChanged;

        [SerializeField] private int _maxHP = 100;

        private void Start()
        {
            _currentHP = 100;
            OnHealthChanged?.Invoke(_currentHP);
        }

        public int GetCurrentHP()
        {
            return _currentHP;
        }

        public void TakeDamage(int damage)
        {
            if (_currentHP - damage < 0)
            {
                _currentHP = 0;
            }
            else
            {
                _currentHP -= damage;
            }
            OnHealthChanged?.Invoke(_currentHP);
        }

        public void TakeHeal(int heal)
        {
            if (_currentHP + heal > _maxHP)
            {
                _currentHP = _maxHP;
            }
            else
            {
                _currentHP += heal;
                OnHealthChanged?.Invoke(_currentHP);
            }
        }
    }
}

