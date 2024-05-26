using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ChromaticObberation : MonoBehaviour
{
    [SerializeField] private Volume volume;
    [SerializeField] private ChromaticAberration chromaticAberration;
    [SerializeField] private PaniniProjection paniniProjection; 
    [SerializeField] private float minValue = 0f;
    [SerializeField] private float maxValue = 1f;
    [SerializeField] private float transitionSpeed = 1f;
    [SerializeField] private float minWaitTime = 5f;
    [SerializeField] private float maxWaitTime = 10f;
    [SerializeField] private float _duration = 5f;
    [SerializeField] private float paniniMinDistance = 0f;
    [SerializeField] private float paniniMaxDistance = 1f;

    private void Start()
    {
        if (volume.profile.TryGet<ChromaticAberration>(out chromaticAberration) && volume.profile.TryGet<PaniniProjection>(out paniniProjection))
        {
            StartCoroutine(ChangeChromaticAberration());
        }
    }

    private IEnumerator ChangeChromaticAberration()
    {
        while (true)
        {
            yield return StartCoroutine(LerpChromaticAberration(minValue, maxValue));
            yield return new WaitForSeconds(_duration);
            yield return StartCoroutine(LerpChromaticAberration(maxValue, minValue));
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        }
    }

    private IEnumerator LerpChromaticAberration(float startValue, float endValue)
    {
        float elapsedTime = 0f;
        while (elapsedTime < transitionSpeed)
        {
            float t = elapsedTime / transitionSpeed;
            chromaticAberration.intensity.value = Mathf.Lerp(startValue, endValue, t);
            if (chromaticAberration.intensity.value != 0f)
            {
                paniniProjection.distance.value = Mathf.Lerp(paniniMinDistance, paniniMaxDistance, t);
            }
            else
            {
                paniniProjection.distance.value = paniniMinDistance;
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        chromaticAberration.intensity.value = endValue;
        if (chromaticAberration.intensity.value != 0f)
        {
            paniniProjection.distance.value = paniniMaxDistance;
        }
        else
        {
            paniniProjection.distance.value = paniniMinDistance;
        }
    }
}
