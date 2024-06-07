using BattleIsland.Infrastructure.Presenter;
using BattleIsland.Infrastructure.View;
using BattleIsland.Infrustructure.Model;
using UnityEngine;

namespace BattleIsland.Infrastructure
{
    public class MenuSetup : MonoBehaviour
    {
        [SerializeField] private MenuView _menuView;

        private void Awake()
        {
            Menu menu = new Menu();
            MenuPresenter menuPresenter = new(menu);
            _menuView.Init(menuPresenter);
        }
    }
}