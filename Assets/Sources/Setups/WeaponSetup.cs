using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleIsland.Model;

public class WeaponSetup : MonoBehaviour
{
    [SerializeField] private WeaponShootView _shootView;
    [SerializeField] private WeaponFollowParentView _followParentView;

    private Weapon _model;
    private WeaponShootPresenter _shootPresenter;
    private WeaponFollowParentPresenter _followParentPresenter;

    private void Awake()
    {
        _model = new Weapon();
        _shootPresenter = new WeaponShootPresenter(_model, _shootView);
        _followParentPresenter = new WeaponFollowParentPresenter(_model, _followParentView);
    }

    private void OnEnable()
    {
        _shootPresenter.Enable();
        _followParentPresenter.Enable();
    }

    private void OnDisable()
    {
        _shootPresenter.Disable();
        _followParentPresenter.Disable();
    }
}
