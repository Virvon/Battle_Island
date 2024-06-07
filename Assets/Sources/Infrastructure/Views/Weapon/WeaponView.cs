using System;
using UnityEngine;

namespace BattleIsland.Infrastructure.View
{
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class WeaponView : MonoBehaviour
    {
        public MovementObject Parent => _parent;
        public Transform IdlePosition => _idlePosition;
        public Rigidbody Rigidbody { get; private set; }

        private MovementObject _parent;
        private Transform _idlePosition;
        private Collider _collider;

        public event Action Inited;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
        }

        public void Init(MovementObject parent, Transform idlePosition)
        {
            _parent = parent;
            _idlePosition = idlePosition;
            Inited?.Invoke();
        }

        public void Activate()
        {
            _collider.enabled = true;
            Rigidbody.isKinematic = false;
        }

        public void Deactivate()
        {
            _collider.enabled = false;
            Rigidbody.isKinematic = true;
        }
    }

}