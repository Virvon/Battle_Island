using BattleIsland.Infrastructure.Presenter;
using BattleIsland.Infrastructure.View.Menu;
using UnityEngine;

namespace BattleIsland.Infrastructure.Setup.Menu
{
    public class MenuSetup : MonoBehaviour
    {
        [SerializeField] private MenuView _menuView;

        private void Awake()
        {
            Infrustructure.Model.Menu menu = new Infrustructure.Model.Menu();
            MenuPresenter menuPresenter = new(menu);
            _menuView.Init(menuPresenter);
        }
    }
}