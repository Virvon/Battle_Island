using BattleIsland.Infrastructure.View;
using System.Collections;
using UnityEngine;

namespace BattleIsland.Animation
{
    [RequireComponent(typeof(MovementObject))]
    public class UnitAnimaions : MonoBehaviour
    {
        private Animator _animator;
        private MovementObject _unit;
        private bool _isDead;

        private void Start()
        {
            _isDead = false;

            _animator = GetComponentInChildren<Animator>();
            _unit = GetComponent<MovementObject>();

            _unit.PositionChanged += OnPositionChanged;
            _unit.Stopped += OnStopped;
            _unit.Died += OnDied;
        }

        private void OnDisable()
        {
            _unit.PositionChanged -= OnPositionChanged;
            _unit.Stopped -= OnStopped;
            _unit.Died -= OnDied;
        }

        private void OnPositionChanged()
        {
            if (_isDead == false)
                _animator.SetBool(AnimationPath.Unit.IsRun, true);
        }

        private void OnStopped()
        {
            _animator.SetTrigger(AnimationPath.Unit.Attack);
            _animator.SetBool(AnimationPath.Unit.IsRun, false);
        }

        private void OnDied()
        {
            _animator.SetBool(AnimationPath.Unit.IsRun, false);

            StartCoroutine(DeadController());
        }

        private IEnumerator DeadController()
        {
            _isDead = true;

            yield return new WaitForSeconds(0.1f);

            _isDead = false;
        }
    }
}