using UnityEngine;

namespace BattleIsland.GameLogic
{
    [RequireComponent(typeof(Obstacle))]
    public class ObstacleParticles : MonoBehaviour
    {
        [SerializeField] private GameObject _particles;

        private Obstacle _let;

        private void OnEnable()
        {
            _let = GetComponent<Obstacle>();

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
}