using System;
using UnityEngine;

namespace Assets.Sources.GameLogic.Learning.Triggers
{
    public class StartTrigger : MonoBehaviour, ITriggerable
    {
        public event Action Triggered;

        private void Start() =>
            Triggered?.Invoke();
    }
}