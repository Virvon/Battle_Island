using System;
using UnityEngine;

namespace Assets.Sources.Infrastructure.Models
{
    public class Player
    {
        private const float VelocityForce = 6.5f;
        private const int LookDireciton = 45;
        private const int RotationSpeed = 1080;

        public event Action Rotated;
        public event Action Moved;

        public Quaternion Rotation { get; private set; }
        public Vector3 Velocity { get; private set; }

        public void Rotate(Vector2 direction, float deltaTime)
        {
            var lookDirection = Quaternion.Euler(0, LookDireciton, 0) * new Vector3(direction.x, 0, direction.y);
            var targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
            var currentRotation = Quaternion.RotateTowards(Rotation, targetRotation, RotationSpeed * deltaTime);

            Rotate(currentRotation);
            Move(direction.magnitude);
        }

        private void Rotate(Quaternion rotation)
        {
            Rotation = rotation;
            Rotated?.Invoke();
        }

        private void Move(float force)
        {
            Velocity = Rotation * Vector3.forward * VelocityForce * force;
            Moved?.Invoke();
        }
    }
}