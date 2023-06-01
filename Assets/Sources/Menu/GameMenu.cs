using UnityEngine;

public class GameMenu : Menu
{
    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private GameTimer _timer;
    [SerializeField] private UnitsSpawner _enemySpawner;

    private const string NextScene = "Menu";

    private void OnEnable()
    {
        _timer.TimeOvered += OpenResultPanel;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
        _timer.TimeOvered -= OpenResultPanel;
    }

    private void OpenResultPanel()
    {
        _resultPanel.SetActive(true);

        Time.timeScale = 0;
    }

    public override string GetScene()
    {
        return NextScene;
    }
}
