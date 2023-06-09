using UnityEngine;
using BattleIsland.Model;

[RequireComponent(typeof(PlayerView))]
public class PlayerSetup : MonoBehaviour
{
    private PlayerView _view;
    private Player _model;
    private PlayerPresenter _presenter;

    private void Awake()
    {
        _view = GetComponent<PlayerView>();

        _model = new Player();
        _presenter = new PlayerPresenter(_model, _view);
    }

    private void OnEnable()
    {
        _presenter.Enable();
    }

    private void OnDisable()
    {
        _presenter.Disable();
    }
}
