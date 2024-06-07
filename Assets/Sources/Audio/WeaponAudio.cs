using UnityEngine;

namespace BattleIsland.Audio
{
    public class WeaponAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource _shootAudio;
        [SerializeField] private AudioSource _hitAudio;

        public void PlayShootAudio()
        {
            _shootAudio.Play();
        }

        public void PlayHitAudio()
        {
            _hitAudio.Play();
        }
    }
}