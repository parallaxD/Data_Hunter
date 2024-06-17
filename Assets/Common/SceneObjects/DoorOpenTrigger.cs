using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
