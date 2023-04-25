using System.Collections;
using UnityEngine;

public class Let : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private bool _isStatic = false;

    private Vector3 _startPosition;
    private Coroutine _coroutine;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isStatic)
            return;

        if(collision.collider.TryGetComponent(out WeaponView weapon))
        {
            _health--;

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            if (_health > 0)
                _coroutine = StartCoroutine(DamageAnimation(5, new Vector3(0, -0.2f, 0)));
            else
                _coroutine = StartCoroutine(DeadAnimation(2, new Vector3(0, -10, 0)));
        }
    }

    private IEnumerator DamageAnimation(float speed, Vector3 direction)
    {
        Vector3 targetPosition = _startPosition + direction;
        float time = 0;

        while ((transform.position - targetPosition).magnitude > 0.1f)
        {
             time += Time.deltaTime * speed;

            transform.position = Vector3.Lerp(_startPosition, targetPosition, time);

            yield return null;
        }

        time = 0;

        while((transform.position - _startPosition).magnitude > 0.1f)
        {
            time += Time.deltaTime * speed;

            transform.position = Vector3.Lerp(targetPosition, _startPosition, time);

            yield return null;
        }
    } 

    private IEnumerator DeadAnimation(float speed, Vector3 direction)
    {
        Vector3 targetPosition = _startPosition + direction;
        float time = 0;

        while ((transform.position - targetPosition).magnitude > 0.1f)
        {
            time += Time.deltaTime * speed;

            transform.position = Vector3.Lerp(_startPosition, targetPosition, time);

            yield return null;
        }

        gameObject.SetActive(false);
    }
}
