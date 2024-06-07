using UnityEngine;
using UnityEngine.Audio;

namespace BattleIsland.Audio
{
    public class AudioVolumeToggler : MonoBehaviour
    {
        private const string AudioMixerName = "MusicVolume";

        private const int IncludedSoundVolume = 0;
        private const int SwitchedOffSoundVolume = -80;

        [SerializeField] private AudioMixerGroup _mixerGroup;

        public void ToggleSound(bool isEnebled)
        {
            if (isEnebled)
                _mixerGroup.audioMixer.SetFloat(AudioMixerName, IncludedSoundVolume);
            else
                _mixerGroup.audioMixer.SetFloat(AudioMixerName, SwitchedOffSoundVolume);
        }
    }
}