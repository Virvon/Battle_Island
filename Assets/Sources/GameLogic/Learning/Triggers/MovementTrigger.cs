using System;
using Assets.Sources.Input;
using UnityEngine;

namespace Assets.Sources.GameLogic.Learning.Triggers
{
    public class MovementTrigger : MonoBehaviour, ITriggerable
    {
        [SerializeField] private DirectionInput _directionInput;

        public event Action Triggered;

        private void OnEnable() =>
            _directionInput.Activated += OnActivated;

        private void OnDisable() =>
            _directionInput.Activated -= OnActivated;

        private void OnActivated() =>
            Triggered?.Invoke();
    }
}