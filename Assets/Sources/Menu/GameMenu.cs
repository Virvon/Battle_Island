using UnityEngine;
using UnityEngine.Audio;

public class GameMenu : Menu
{
    private const int IncludedSoundVolume = 0;
    private const int SwitchedOffSoundVolume = -80;

    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private GameTimer _timer;
    [SerializeField] private UnitsSpawner _enemySpawner;
    [SerializeField] private LeaderBoard _leaderboard;
    [SerializeField] private InBackgroundRunner _inBackgroundRunner;
    [SerializeField] private AudioMixerGroup _mixerGroup;

    private const SceneNames NextScene = SceneNames.Menu;


    private void OnEnable()
    {
        Advertisement.QuickAdClosed += OnQuickAdClosed;
        Advertisement.QuickAdErrored += OnQuickAdErrored;
        Advertisement.VideoAdClosed += VideoAdClosed;
        Advertisement.AdOpened += AdOpened;
        _timer.TimeOvered += OpenResultPanel;

        _inBackgroundRunner.enabled = true;
    }

    private void OnDisable()
    {
        Advertisement.QuickAdClosed -= OnQuickAdClosed;
        Advertisement.QuickAdErrored -= OnQuickAdErrored;
        Advertisement.VideoAdClosed -= VideoAdClosed;
        Advertisement.AdOpened -= AdOpened;
        _timer.TimeOvered -= OpenResultPanel;
    }

    private void OpenResultPanel()
    {
        _resultPanel.SetActive(true);

        Time.timeScale = 0;
        _inBackgroundRunner.enabled = false;
    }

    private void OnQuickAdClosed(bool isClosed)
    {
        if (isClosed)
        {
            _mixerGroup.audioMixer.SetFloat("MusicVolume", IncludedSoundVolume);

            base.LoadNextScene();
        }
    }

    private void OnQuickAdErrored(string error)
    {
        Debug.Log(JsonUtility.ToJson(error));

        base.LoadNextScene();
    }

    private void AdOpened() => 
        _mixerGroup.audioMixer.SetFloat("MusicVolume", SwitchedOffSoundVolume);

    private void VideoAdClosed()
    {
        _mixerGroup.audioMixer.SetFloat("MusicVolume", IncludedSoundVolume);

        base.LoadNextScene();
    }

    public override void LoadNextScene()
    {
#if UNITY_WEBGL || !UNITY_EDITOR
        Advertisement.ShowQuickAd();
#else
        base.LoadNextScene();
#endif
    }

    public override SceneNames GetScene() => 
        NextScene;
}
