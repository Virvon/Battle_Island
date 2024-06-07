using BattleIsland.Model;
using UnityEngine;

public class GameMenuPresenter : MenuPresenter
{
    private readonly GameMenu _gameMenu;
    private readonly GameObject _resultPanel;
    private readonly InBackgroundRunner _inBackgroundRunner;

    public GameMenuPresenter(GameMenu gameMenu, GameObject resultPanel, InBackgroundRunner inBackgroundRunner) : base(gameMenu)
    {
        _gameMenu = gameMenu;
        _resultPanel = resultPanel;
        _inBackgroundRunner = inBackgroundRunner;

        _inBackgroundRunner.enabled = true;

        _gameMenu.ResultPanelOpened += OnResultPanelOpened;
    }

    ~GameMenuPresenter()
    {
        _gameMenu.ResultPanelOpened -= OnResultPanelOpened;
    }

    public void OpenResultPanel() =>
        _gameMenu.OpenResultPanel();

    private void OnResultPanelOpened()
    {
        _resultPanel.SetActive(true);

        Time.timeScale = 0;
        _inBackgroundRunner.enabled = false;
    }
}