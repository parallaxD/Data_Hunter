
using System;

namespace Common.Entity
{
    public interface IDamageable
    {
        int getHP();
        void setHP(int hp);
        void applyDamage(int hp);
        void die();
        Action onDie();
    }
}