using Assets.Sources.Infrastructure.Models;
using Assets.Sources.Infrastructure.Presenters;
using Assets.Sources.Infrastructure.Views.Menu;
using Assets.Sources.UI;
using UnityEngine;

namespace Assets.Sources.Infrastructure.Setups.Menu
{
    public class GameMenuSetup : MonoBehaviour
    {
        [SerializeField] private MenuView _menuView;
        [SerializeField] private GameObject _resultPanel;
        [SerializeField] private InBackgroundRunner _inBackgroundRunner;

        private void Awake()
        {
            GameMenu gameMenu = new();
            GameMenuPresenter presenter = new(gameMenu, _resultPanel, _inBackgroundRunner);
            _menuView.Init(presenter);
        }
    }
}