using System.Collections;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private float _liftingDistance = 5f;
    [SerializeField] private float _liftingSpeed = 1f;

    private Vector3 _initialPosition;
    private Vector3 _targetPosition;
    private bool _isMovingUp = false;

    private IEnumerator Start()
    {
        _initialPosition = transform.position;
        _targetPosition = _initialPosition + Vector3.up * _liftingDistance;

        while (true)
        {
            if (_isMovingUp)
                yield return StartCoroutine(Elevate(_targetPosition));
            else
                yield return StartCoroutine(Elevate(_initialPosition));
        }
    }

    private IEnumerator Elevate(Vector3 targetPosition)
    {
        while (Mathf.Abs(transform.position.y - targetPosition.y) > 0.01f)
        {
            float step = _liftingSpeed * Time.deltaTime * (_isMovingUp ? 1f : -1f);
            transform.Translate(Vector3.up * step);
            yield return null;
        }
    }
}
