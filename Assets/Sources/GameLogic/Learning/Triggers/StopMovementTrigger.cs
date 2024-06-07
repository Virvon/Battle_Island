using BattleIsland.Input;
using System;
using UnityEngine;

namespace BattleIsland.GameLogic.Learning
{
    public class StopMovementTrigger : MonoBehaviour, ITriggerable
    {
        [SerializeField] private DirectionInput _directionInput;

        public event Action Triggered;

        private void OnEnable() => _directionInput.Deactivated += OnActivated;

        private void OnDisable() => _directionInput.Deactivated -= OnActivated;

        private void OnActivated() => Triggered?.Invoke();
    }
}