using UnityEngine;

[RequireComponent(typeof(Let))]
public class LetParticles : MonoBehaviour
{
    [SerializeField] private GameObject _particles;

    private Let _let;

    private void OnEnable()
    {
        _let = GetComponent<Let>();

        _let.Broked += OnBroked;
    }

    private void OnDisable()
    {
        _let.Broked -= OnBroked;
    }

    private void OnBroked()
    {
        Instantiate(_particles, transform.position, Quaternion.identity);
    }
}
