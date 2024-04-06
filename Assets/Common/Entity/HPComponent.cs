using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Common.Entity
{
    public class HPComponent : MonoBehaviour, IDamageable
    {
        private const int MAX_HP = 100; 
        private int _healPoints;
        [CanBeNull] private event Action OnDieEvent; 

        public int getHP()
        {
            return _healPoints;
        }

        public void setHP(int hp)
        {
            if (hp > MAX_HP)
            {
                _healPoints = MAX_HP;
                return;
            }

            if (hp < 0)
            {
                die();
                return;
            }

            _healPoints = hp;
        }

        public void applyDamage(int hp)
        {
            _healPoints -= hp;
        }

        public void die()
        {
            _healPoints = 0;
            onDie()?.Invoke();
        }

        public Action onDie()
        {
            return OnDieEvent;
        }
    }
}