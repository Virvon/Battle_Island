using System;
using UnityEngine;

namespace BattleIsland.Infrastructure.View.Weapon
{
    [RequireComponent(typeof(WeaponView))]
    public class WeaponFollowParentView : MonoBehaviour
    {
        private WeaponView _weaponView;

        public event Action ParentPositionChanged;

        public void OnEnable()
        {
            _weaponView = GetComponent<WeaponView>();

            _weaponView.Inited += OnInited;
        }

        public void OnDisable()
        {
            _weaponView.Inited -= OnInited;
            _weaponView.Parent.PositionChanged -= OnParentPositionChanged;
        }

        public void ChangePosition()
        {
            transform.position = _weaponView.IdlePosition.position;
            transform.rotation = _weaponView.IdlePosition.rotation;
        }

        private void OnParentPositionChanged() =>
            ParentPositionChanged?.Invoke();

        private void OnInited() =>
            _weaponView.Parent.PositionChanged += OnParentPositionChanged;
    }
}