using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleIsland.Model;

public class EnemyPresenter
{
    private Enemy _model;
    private EnemyView _view;

    public EnemyPresenter(Enemy model, EnemyView view)
    {
        _model = model;
        _view = view;
    }

    public void Enable()
    {
        _model.Moved += OnMoved;
        _model.Died += OnDied;

        //_view.TargetChoosed += OnTargetChoosed;
        //_view.DamageTaked += OnDamageTaked;
    }

    public void Disable()
    {
        _model.Moved -= OnMoved;
        _model.Died -= OnDied;

        //_view.TargetChoosed -= OnTargetChoosed;
        //_view.DamageTaked -= OnDamageTaked;
    }

    private void OnMoved()
    {
        //_view.MoveToTarget();
    }

    private void OnTargetChoosed()
    {
        _model.SetTarget();
    }

    private void OnDamageTaked()
    {
        _model.TakeDamage();
    }

    private void OnDied()
    {
        //_view.Respawn();
    }
}
