using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : Menu
{
    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private GameTimer _timer;
    [SerializeField] private JoystickHandler _joystick;
    [SerializeField] private UnitsSpawner _enemySpawner;

    private void OnEnable()
    {
        _timer.TimeOvered += OpenResultPanel;
    }

    private void OnDisable()
    {
        _timer.TimeOvered -= OpenResultPanel;
    }

    private void OpenResultPanel()
    {
        _resultPanel.SetActive(true);
        _joystick.gameObject.SetActive(false);
        _enemySpawner.DisableEnemies();
    }
}
