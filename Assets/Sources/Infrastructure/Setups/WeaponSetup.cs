using BattleIsland.Infrastructure.Presenter;
using BattleIsland.Infrastructure.View;
using BattleIsland.Infrustructure.Model;
using UnityEngine;

namespace BattleIsland.Infrastructure
{
    [RequireComponent(typeof(WeaponShootView), typeof(WeaponFollowParentView))]
    public class WeaponSetup : MonoBehaviour
    {
        private WeaponShootView _shootView;
        private WeaponFollowParentView _followParentView;
        private Weapon _model;
        private WeaponShootPresenter _shootPresenter;
        private WeaponFollowParentPresenter _followParentPresenter;

        private void Awake()
        {
            _shootView = GetComponent<WeaponShootView>();
            _followParentView = GetComponent<WeaponFollowParentView>();

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
}