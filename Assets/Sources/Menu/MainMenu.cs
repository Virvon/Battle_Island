using UnityEngine;

public class MainMenu : Menu
{
    [SerializeField] private GameObject _settingsPanel;

    public void OpenSettingsPanel()
    {
        _settingsPanel.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        _settingsPanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
