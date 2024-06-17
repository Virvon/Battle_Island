using UnityEngine;

namespace Assets.Sources.GameLogic.Obstacle
{
    [RequireComponent(typeof(Obstacle))]
    public class ObstacleAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource _hitAudio;
        [SerializeField] private AudioSource _dieAudio;

        private Obstacle _let;

        private void OnEnable()
        {
            _let = GetComponent<Obstacle>();

            _let.Hited += StartHitAudio;
            _let.Broked += StartDieAudio;
        }

        private void OnDisable()
        {
            _let.Hited -= StartHitAudio;
            _let.Broked -= StartDieAudio;
        }

        private void StartHitAudio()
        {
            _hitAudio.Play();
        }

        private void StartDieAudio()
        {
            _dieAudio.Play();
        }
    }
}