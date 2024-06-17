using System;
using UnityEngine;

namespace Assets.Sources.GameLogic.Learning.Triggers
{
    public class ObstacleBrokedTrigger : MonoBehaviour, ITriggerable
    {
        [SerializeField] private Obstacle.Obstacle _let;

        public event Action Triggered;

        private void OnEnable() =>
            _let.Broked += Triggered;

        private void OnDisable() =>
            _let.Broked -= Triggered;
    }
}