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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                TakeDamage(90);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                TakeHeal(90);
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
            print('d');
            if (_currentHP - damage < 0)
            {
                _currentHP = 0;
            }
            else
            {
                _currentHP -= damage;
            }
            print(_currentHP);
            OnHealthChanged?.Invoke(_currentHP);
        }

        public void TakeHeal(int heal)
        {
            print('h');
            if (_currentHP + heal > _maxHP)
            {
                _currentHP = _maxHP;
            }
            else 
            { 
                _currentHP += heal; 
            }
            print(_currentHP);
            OnHealthChanged?.Invoke(_currentHP);
        }
    }
}
