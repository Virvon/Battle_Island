using System;
using UnityEngine;

namespace BattleIsland.Model
{
    public class Weapon
    {
        private State _state;

        public Weapon() => 
            _state = new IdleState();

        public event Action Shotted;

        public event Action Comeback;

        public event Action PositionChanged;

        public event Action<Vector3> TrajectoryChanged;

        public void TryShoot()
        {
            if (_state.CanShoot())
                Shotted?.Invoke();
        }

        public void TryComeback()
        {
            if (_state.CanComeback())
                Comeback?.Invoke();
        }

        public void SetState(State state) =>
            _state = state;

        public void TryChangePosition()
        {
            if (_state.CanShoot())
                PositionChanged?.Invoke();
        }

        public void ChangeTrajectory(Vector3 forward, Vector3 normal)
        {
            var resultDirection = Vector3.Reflect(forward, normal);

            TrajectoryChanged?.Invoke(resultDirection);
        }
    }
}