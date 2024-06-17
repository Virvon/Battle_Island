using BattleIsland.Infrastructure.Presenter;
using BattleIsland.Infrastructure.View.Menu;
using BattleIsland.Infrustructure.Model;
using BattleIsland.UI;
using UnityEngine;

namespace BattleIsland.Infrastructure.Setup.Menu
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