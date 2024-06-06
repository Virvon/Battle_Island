using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] private GameObject _effect;

    private GameObject _currentEffect;

    public void Activate()
    {
        if (_currentEffect == null)
            _currentEffect = InstantiateEffect();

        _currentEffect.SetActive(true);
    }

    public void Deactivate()
    {
        if (_currentEffect != null)
            _currentEffect.SetActive(false);
    }

    private GameObject InstantiateEffect() =>
        Instantiate(_effect, transform.position + new Vector3(0, 0.065f, 0.6f), Quaternion.identity, transform);
}