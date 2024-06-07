using UnityEngine;
using UnityEngine.Audio;

public class AudioVolumeToggler : MonoBehaviour
{
    private const int IncludedSoundVolume = 0;
    private const int SwitchedOffSoundVolume = -80;

    [SerializeField] private AudioMixerGroup _mixerGroup;

    public void ToggleSound(bool isEnebled)
    {
        if (isEnebled)
            _mixerGroup.audioMixer.SetFloat("MusicVolume", IncludedSoundVolume);
        else
            _mixerGroup.audioMixer.SetFloat("MusicVolume", SwitchedOffSoundVolume);
    }
}