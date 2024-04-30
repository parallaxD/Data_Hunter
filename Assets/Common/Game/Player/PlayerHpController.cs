using Common.Damage;
using TNRD;
using UnityEngine;

namespace Common.Game.Player
{
    public class PlayerHpController : MonoBehaviour
    {
        [SerializeField] private SerializableInterface<IDamageable> damageable;
        
    }
}