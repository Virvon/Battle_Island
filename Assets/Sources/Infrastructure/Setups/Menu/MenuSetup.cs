using UnityEngine;
using BattleIsland.Model;

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