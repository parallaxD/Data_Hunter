using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections.Generic;
using System;

public class VideoPlayerController : MonoBehaviour
{
    [SerializeField] RawImage _rawImage;
    [SerializeField] VideoPlayer _videoPlayer;
    [SerializeField] List<VideoClip> _videos;
    [SerializeField] GameObject _videoCanvas;

    void Awake()
    {
        _videoPlayer.targetTexture = new RenderTexture(1920, 1080, 0);
        _rawImage.texture = _videoPlayer.targetTexture;
        _videoPlayer.enabled = false;
        _rawImage.enabled = false;
        _videoPlayer.loopPointReached += OnVideoEnd;
        PlayVideo(0);
    }

    private void OnVideoEnd(VideoPlayer videoPlayer)
    {
        if (_videoPlayer.clip == _videos[_videos.Count - 1])
        {
            Cursor.lockState = CursorLockMode.None;
        }
        _videoCanvas.SetActive(false);
    }

    public void PlayVideo(int videoIndex)
    {
        _videoPlayer.enabled = true;
        _rawImage.enabled = true;
        _videoPlayer.clip = _videos[videoIndex];
        _videoPlayer.Play();
    }
}
