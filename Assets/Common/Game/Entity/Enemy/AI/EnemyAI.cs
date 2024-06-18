using System;
using Common.Storage;
using UnityEngine;
using UnityEngine.AI;

namespace Common.Game.Entity.Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        private Transform _target;
        private NavMeshAgent _agent;
        private Hand Hand;
        [SerializeField] private Common.Entity.Enemy enemy;
        [SerializeField] private float lookRadius = 20;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void FixedUpdate()
        {
            var distanceToTarget = Vector3.Distance(_target.position, transform.position);

            if (lookRadius >= distanceToTarget)
            {
                if (_agent.stoppingDistance >= distanceToTarget)
                {
                    LookToTarget();
                }
                _agent.SetDestination(_target.position);
                enemy.Shoot();
            }
        }

        private void LookToTarget()
        {
            var lookDirection = (_target.position - transform.position).normalized;
            lookDirection.y = 0;
            
            var lookRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.fixedTime);
        }
    }
}