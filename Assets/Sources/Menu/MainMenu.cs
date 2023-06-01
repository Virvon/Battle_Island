using BattleIsland.SaveData;
using UnityEngine;

public class MainMenu : Menu
{
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private string _learningScene;
    [SerializeField] private string _learningSaveKey;

    public void OpenSettingsPanel() => _settingsPanel.SetActive(true);

    public void CloseSettingsPanel() => _settingsPanel.SetActive(false);

    public override string GetScene()
    {
        if (LoadLearningResult())
            return MapStore.SelectMap;
        else
            return _learningScene;
    }

    private bool LoadLearningResult()
    {
        return SaveManger.Load<LearningProfile>(_learningSaveKey).IsFinish;
    }
}
