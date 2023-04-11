using System;
using UnityEngine;

namespace BattleIsland.Model
{
    public class Player
    {
        public Quaternion Rotation { get; private set; }

        public Vector3 Velocity { get; private set; }

        private float _velocityForce = 6;

        public event Action Rotated;
        public event Action Moved;

        public void Rotate(Vector2 direction, float deltaTime)
        {
            var lookDirection = (Quaternion.Euler(0, 45, 0) * new Vector3(direction.x, 0, direction.y));
            var targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
            var currentRotation = Quaternion.RotateTowards(Rotation, targetRotation, 1080 * deltaTime);

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
            Velocity = Rotation * Vector3.forward * _velocityForce * force;
            Moved?.Invoke();
        }
    }
}
