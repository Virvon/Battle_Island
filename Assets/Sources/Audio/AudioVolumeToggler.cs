using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Sources.Audio
{
    public class AudioVolumeToggler : MonoBehaviour
    {
        private const string AudioMixerName = "MusicVolume";

        private const int IncludedSoundVolume = 0;
        private const int SwitchedOffSoundVolume = -80;

        [SerializeField] private AudioMixerGroup _mixerGroup;

        public void ToggleSound(bool isEnebled)
        {
            float volume = isEnebled ? IncludedSoundVolume : SwitchedOffSoundVolume;

            _mixerGroup.audioMixer.SetFloat(AudioMixerName, volume);
        }
    }
}