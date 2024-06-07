using UnityEngine;
using BattleIsland.Model;

public class GameMenuSetup : MonoBehaviour
{
    [SerializeField] private MenuView _menuView;
    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private InBackgroundRunner _inBackgroundRunner;

    private void Awake()
    {
        GameMenu gameMenu = new ();
        GameMenuPresenter presenter = new(gameMenu, _resultPanel, _inBackgroundRunner);
        _menuView.Init(presenter);
    }
}