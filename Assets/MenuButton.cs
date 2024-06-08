using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private AudioClip _clipToPlay;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();

        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        _audioSource.clip = _clipToPlay;
        _audioSource.playOnAwake = true;

        _audioSource.enabled = true;
    }

    public void PlaySound()
    {
        if (_audioSource.enabled)
        {
            _audioSource.Play();
        }
    }
}
