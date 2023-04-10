using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleIsland.Model
{
    public class Weapon
    {
        private State _state;

        public event Action Shotted;
        public event Action Comeback;
        public event Action PositionChanged;

        public Weapon()
        {
            _state = new IdleState();
        }

        public void TryShoot()
        {
            if (_state.CanShoot())
                Shotted?.Invoke();
        }

        public void TryComeback()
        {
            if(_state.CanComeback())
                Comeback?.Invoke();
        }

        public void SetState(State state)
        {
            _state = state;
        }

        public void TryChangePosition()
        {
            if(_state.CanShoot())
                PositionChanged?.Invoke();
        }
    }
}
