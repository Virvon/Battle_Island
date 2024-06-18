using Assets.Sources.Infrastructure.Presenters;
using Assets.Sources.Infrastructure.Views.Menu;
using UnityEngine;

namespace Assets.Sources.Infrastructure.Setups.Menu
{
    public class MenuSetup : MonoBehaviour
    {
        [SerializeField] private MenuView _menuView;

        private void Awake()
        {
            Models.Menu menu = new ();
            MenuPresenter menuPresenter = new(menu);
            _menuView.Init(menuPresenter);
        }
    }
}