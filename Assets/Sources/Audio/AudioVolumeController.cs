using UnityEngine;
using UnityEngine.Audio;

public class AudioVolumeController : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;

    public void ToggleSound(bool isEnebled)
    {
        if (isEnebled)
            _mixerGroup.audioMixer.SetFloat("MusicVolume", 0);
        else
            _mixerGroup.audioMixer.SetFloat("MusicVolume", -80);
    }
}
