using System;
using Assets.Sources.Infrastructure.Views;
using UnityEngine;

namespace Assets.Sources.GameLogic.Learning
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class SpatialTrigger : MonoBehaviour
    {
        public event Action PlayerEntered;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerView player))
                PlayerEntered?.Invoke();
        }
    }
}