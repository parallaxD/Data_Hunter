using Common.Damage;

namespace Common.Interactable.Item.Weapon
{
    public class GunDamageProvider : IHpChanger
    {
        private readonly int _damage;

        public GunDamageProvider(int damage)
        {
            _damage = damage;
        }

        public int CalculateHpDiff()
        {
            return -_damage;
        }
    }
}