using System;
using UnityEngine;

namespace BattleIsland.GameLogic.Learning
{
    public class ObstacleBrokedTrigger : MonoBehaviour, ITriggerable
    {
        [SerializeField] private Obstacle _let;

        public event Action Triggered;

        private void OnEnable() => _let.Broked += Triggered;

        private void OnDisable() => _let.Broked -= Triggered;
    }
}