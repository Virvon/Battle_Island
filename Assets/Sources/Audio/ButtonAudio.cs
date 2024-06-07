using UnityEngine;

namespace BattleIsland.Audio
{
    public class ButtonAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource _clickAudio;

        public void PlayeClickAudio()
        {
            _clickAudio.Play();
        }
    }
}