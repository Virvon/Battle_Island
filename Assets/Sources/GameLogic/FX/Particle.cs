using UnityEngine;

namespace BattleIsland.GameLogic
{
    public class Particle : MonoBehaviour
    {
        [SerializeField] private GameObject _effect;
        [SerializeField] private Vector3 _effectSpawnPosition = new Vector3(0, 0.065f, 0.6f);

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
            Instantiate(_effect, transform.position + _effectSpawnPosition, Quaternion.identity, transform);
    }
}