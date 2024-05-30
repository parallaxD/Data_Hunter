using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.Animation;
public class Door : MonoBehaviour, IAnimator
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
    }

    private void PlayOpenAnimation()
    {
        _openAnimation.Play();
    }

    public void RunAnimation()
    {
        foreach (var collider in _doorColliders)
        {
            collider.enabled = false;
        }
        PlayOpenAnimation();
    }
}
