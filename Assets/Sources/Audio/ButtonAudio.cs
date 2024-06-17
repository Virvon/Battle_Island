using UnityEngine;

namespace Assets.Sources.Audio
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