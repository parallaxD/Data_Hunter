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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                TakeDamage(90);
            }
        }

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
            _currentHP -= damage;
            _currentHP = Mathf.Max(_currentHP, 0);
            OnHealthChanged?.Invoke(_currentHP);
        }

        public void TakeHeal(int heal)
        {
            _currentHP += heal;
            _currentHP = Mathf.Max(_currentHP, 0);
            OnHealthChanged?.Invoke(_currentHP);
        }
    }
}
