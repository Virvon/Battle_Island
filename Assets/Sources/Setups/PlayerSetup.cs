using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleIsland.Model;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] private PlayerView _vew;

    private Player _model;
    private PlayerPresenter _presenter;

    private void Awake()
    {
        _model = new Player();
        _presenter = new PlayerPresenter(_model, _vew);
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
