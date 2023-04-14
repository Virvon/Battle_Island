using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleIsland.Model;

[RequireComponent(typeof(EnemyView))]
public class EnemySetup : MonoBehaviour
{
    private EnemyView _view;
    private Enemy _model;
    private EnemyPresenter _presenter;

    private void Awake()
    {
        _view = GetComponent<EnemyView>();

        _model = new Enemy();
        _presenter = new EnemyPresenter(_model, _view);
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
