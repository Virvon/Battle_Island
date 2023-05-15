using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    [SerializeField] private GameObject _effect;

    private GameObject _currentEffect;

    public void Activate()
    {
        if (_currentEffect == null)
            _currentEffect = Instantiate(_effect, transform.position + new Vector3(0, 0.065f, 0.6f), Quaternion.identity, transform);

        _currentEffect.SetActive(true);
    }

    public void Deactivate()
    {
        if (_currentEffect != null)
            _currentEffect.SetActive(false);
    }
}
