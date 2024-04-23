using System;
using Common.Util;

namespace Common.Damage
{
    public interface IDamageable : IUnityObject
    {
        event Action<IHpChanger> OnDamage;
        event Action<IHpChanger> OnHeal;
        event Action<IDamageable> OnDestroy;
        void Apply(IHpChanger hpChanger);
        int GetHp();
        int GetMaxHp();
    }
}