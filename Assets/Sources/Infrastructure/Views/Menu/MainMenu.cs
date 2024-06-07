using BattleIsland.SaveData;
using UnityEngine;

public class MainMenu : MenuView
{
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private SceneId _learningScene;
    [SerializeField] private string _learningSaveKey;

    public void OnEnable() => 
        Time.timeScale = 1;

    public void OpenSettingsPanel() =>
        _settingsPanel.SetActive(true);

    public void CloseSettingsPanel() => 
        _settingsPanel.SetActive(false);

    public override SceneId GetScene()
    {
        if (LoadLearningResult())
            return MapStore.SelectMap;
        else
            return _learningScene;
    }

    private bool LoadLearningResult() =>
        SaveLoadService.Load<LearningProfile>(_learningSaveKey).IsFinish;
}