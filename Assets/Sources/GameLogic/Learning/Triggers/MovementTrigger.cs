using BattleIsland.Input;
using System;
using UnityEngine;

namespace BattleIsland.GameLogic.Learning
{
    public class MovementTrigger : MonoBehaviour, ITriggerable
    {
        [SerializeField] private DirectionInput _directionInput;

        public event Action Triggered;

        private void OnEnable() => 
            _directionInput.Activated += OnActivated;

        private void OnDisable() => 
            _directionInput.Activated -= OnActivated;

        private void OnActivated() => Triggered?.Invoke();
    }
}