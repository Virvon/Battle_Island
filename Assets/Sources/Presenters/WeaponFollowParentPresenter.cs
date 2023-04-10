using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleIsland.Model;

public class WeaponFollowParentPresenter
{
    private Weapon _model;
    private WeaponFollowParentView _view;

    public WeaponFollowParentPresenter(Weapon model, WeaponFollowParentView view)
    {
        _model = model;
        _view = view;
    }

    public void Enable()
    {
        _model.PositionChanged += OnPositionChanged;

        _view.PlayerPositionChanged += TryChangePosition;
    }

    public void Disable()
    {
        _model.PositionChanged -= OnPositionChanged;

        _view.PlayerPositionChanged -= TryChangePosition;
    }

    private void OnPositionChanged()
    {
        _view.ChangePosition();
    }

    private void TryChangePosition()
    {
        _model.TryChangePosition();
    }
}
