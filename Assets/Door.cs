using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Door : MonoBehaviour
{
    List<Collider> _doorColliders;
    Animation _openAnimation;
    private void Start()
    {
        _doorColliders = new List<Collider>();
        foreach (var collider in GetComponentsInChildren<Collider>())
        {
            _doorColliders.Add(collider);
        }
        _openAnimation = GetComponent<Animation>();
        OpenDoor();
    }

    private void OpenDoor()
    {
        foreach (var collider in _doorColliders)
        {
            collider.enabled = false;
            PlayOpenAnimation();
        }
    }

    private void PlayOpenAnimation()
    {
        _openAnimation.Play();
    }
}
