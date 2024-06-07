using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayRotateAnim()
    {
        _animator.Play("MenuCameraRotate");
    }

    public void PlayRotateAnimReversed()
    {
        _animator.Play("MenuCameraRotateReversed");
    }
}
