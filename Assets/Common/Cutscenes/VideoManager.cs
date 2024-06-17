using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : MonoBehaviour
{
    [SerializeField] private VideoPlayerController _videoPlayerController;
    [SerializeField] private bool _playOnAwake;

    private void Start()
    {
        if (_playOnAwake) _videoPlayerController.PlayVideo(0);
    }

    public void StartCutscene(int cutsceneIndex)
    {
        _videoPlayerController.PlayVideo(cutsceneIndex);
    }
}
