using System.Collections;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    private VideoManager _videoManager;

    [SerializeField] private ScreenFader _screenFader;
    [SerializeField] private int cutsceneIndexToStart;
    [SerializeField] private Vector3 _playerCoordinates;

    private void Start()
    {
        _videoManager = GameObject.Find("VideoManager").GetComponent<VideoManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            StartCoroutine(StartCutsceneWithFade());
        }
    }

    private IEnumerator StartCutsceneWithFade()
    {
        yield return StartCoroutine(_screenFader.FadeOut());
        _videoManager.StartCutscene(cutsceneIndexToStart);
        yield return StartCoroutine(_screenFader.FadeIn());
        Destroy(gameObject);
    }
}
