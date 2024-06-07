using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Let))]
public class LetAnimation : MonoBehaviour
{
    private const float Delta = 0.1f;

    [SerializeField] private float _hitAnimationSpeed = 5;
    [SerializeField] private float _dieAnimationSpeed = 2;

    [SerializeField] private Vector3 _hitAnimationAmplitude = new Vector3(0, -0.2f, 0);
    [SerializeField] private Vector3 _dieAnimationAmplitude = new Vector3(0, -10, 0);

    private Vector3 _startPosition;
    private Coroutine _coroutine;
    private Let _let;

    private void OnEnable()
    {
        _let = GetComponent<Let>();
        _startPosition = transform.position;

        _let.Hited += OnHited;
        _let.Broked += OnBroked;
    }

    private void OnDisable()
    {
        _let.Hited -= OnHited;
        _let.Broked -= OnBroked;
    }

    private void OnHited()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(HitAnimation(_hitAnimationSpeed, _hitAnimationAmplitude));
    }

    private void OnBroked()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(DieAnimation(_dieAnimationSpeed, _dieAnimationAmplitude));
    }

    private IEnumerator HitAnimation(float speed, Vector3 direction)
    {
        Vector3 targetPosition = _startPosition + direction;
        float time = 0;

        while ((transform.position - targetPosition).magnitude > Delta)
        {
            time += Time.deltaTime * speed;

            transform.position = Vector3.Lerp(_startPosition, targetPosition, time);

            yield return null;
        }

        time = 0;

        while ((transform.position - _startPosition).magnitude > Delta)
        {
            time += Time.deltaTime * speed;

            transform.position = Vector3.Lerp(targetPosition, _startPosition, time);

            yield return null;
        }
    }

    private IEnumerator DieAnimation(float speed, Vector3 direction)
    {
        Vector3 targetPosition = _startPosition + direction;
        float time = 0;

        while ((transform.position - targetPosition).magnitude > Delta)
        {
            time += Time.deltaTime * speed;

            transform.position = Vector3.Lerp(_startPosition, targetPosition, time);

            yield return null;
        }

        gameObject.SetActive(false);
    }
}
