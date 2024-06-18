
using UnityEngine;

namespace Common.SceneObjects
{
    public class EnemyDoorAnimationStarter : MonoBehaviour
    {
        private Game.Entity.Objects.Door _door;
        private Animator _animator;

        private void Start()
        {
            _door = transform.GetComponent<Game.Entity.Objects.Door>();
            _animator = transform.GetComponent<Animator>();
            _door.OnDoorOpen += () =>
            {
                _animator.Play("PersonDoorOpen");
            };
        }
    }
}