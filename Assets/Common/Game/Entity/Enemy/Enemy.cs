using System.Collections.Generic;
using Common.Core.Interactable.Item;
using Common.Damage;
using Common.Game.Items.Weapon;
using Common.Storage;
using UnityEngine;

namespace Common.Entity
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Gun gun;
        [SerializeField] private Hand hand;
        [SerializeField] private ShootController shootController;
        private IDamageable _damageable;
        [SerializeField] private Transform startShootPosition;
        [SerializeField] private Animator _animator;

        public bool isDead = false;

        private static readonly HashSet<string> IgnoredTags = new()
        {
            "Enemy"
        };

        private void Start()
        {
            gun.SetState(ItemState.InHand(hand));
            _damageable = GetComponent<IDamageable>();
            _damageable.OnDestroy += d =>
            {
                _animator.SetBool("dead", true);
                isDead = true;
            };
        }

        public void Shoot()
        {
            if (Random.value > 0.01)
                return;
            
            var spread = Random.insideUnitCircle * 1.2f;
            hand.InteractionPosition.position = startShootPosition.position + new Vector3(spread.x, 0, spread.y);
            shootController.Shoot(IgnoredTags);
        }
    }
}