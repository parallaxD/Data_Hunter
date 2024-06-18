using UnityEngine;

namespace Common.SceneObjects
{
    public class DoorTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject _doorToOpen;
        [SerializeField] private float _animSpeed;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CharacterController>() != null)
            {
                var animator = _doorToOpen.GetComponent<Animator>();
                animator.SetFloat("speed", _animSpeed);
                animator.Play("PersonDoorOpen");
                Destroy(gameObject);
            }
        }
    }
}
