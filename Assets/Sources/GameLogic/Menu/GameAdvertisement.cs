using UnityEngine;
using UnityEngine.Audio;

public class GameAdvertisement : MonoBehaviour 
{
    private const int IncludedSoundVolume = 0;
    private const int SwitchedOffSoundVolume = -80;

    [SerializeField] private GameMenuView _gameMenu;
    [SerializeField] private AudioMixerGroup _mixerGroup;

    private void OnEnable()
    {
        Advertisement.QuickAdClosed += OnQuickAdClosed;
        Advertisement.QuickAdErrored += OnQuickAdErrored;
        Advertisement.VideoAdClosed += VideoAdClosed;
        Advertisement.AdOpened += AdOpened;
    }

    private void OnDisable()
    {
        Advertisement.QuickAdClosed -= OnQuickAdClosed;
        Advertisement.QuickAdErrored -= OnQuickAdErrored;
        Advertisement.VideoAdClosed -= VideoAdClosed;
        Advertisement.AdOpened -= AdOpened;
    }

    public void ShowAdThenLoadNextScene()
    {
#if UNITY_WEBGL || !UNITY_EDITOR
        Advertisement.ShowQuickAd();
#else
        LoadNextScene();
#endif
    }

    private void LoadNextScene() =>
        _gameMenu.LoadNextScene();

    private void OnQuickAdClosed(bool isClosed)
    {
        if (isClosed)
        {
            _mixerGroup.audioMixer.SetFloat("MusicVolume", IncludedSoundVolume);
            LoadNextScene();
        }
    }

    private void OnQuickAdErrored(string error)
    {
        Debug.Log(JsonUtility.ToJson(error));
        LoadNextScene();
    }

    private void AdOpened() =>
        _mixerGroup.audioMixer.SetFloat("MusicVolume", SwitchedOffSoundVolume);

    private void VideoAdClosed()
    {
        _mixerGroup.audioMixer.SetFloat("MusicVolume", IncludedSoundVolume);
        LoadNextScene();
    }
}
