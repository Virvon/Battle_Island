using System;
using UnityEngine;

namespace BattleIsland.Model
{
    public class Player
    {
        public Quaternion Rotation { get; private set; }
        public Vector3 Position { get; private set; }

        public event Action Rotated;
        public event Action Moved;

        public Player()
        {
            Position = new Vector3(0, 0.5f, 0);
        }

        public void Rotate(Vector2 direction, float deltaTime)
        {
            var lookDirection = (Quaternion.Euler(0, 45, 0) * new Vector3(direction.x, 0, direction.y));
            var targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
            var currentRotation = Quaternion.RotateTowards(Rotation, targetRotation, 1080 * deltaTime);

            Rotate(currentRotation);
            Move(direction.magnitude, deltaTime);
        }

        private void Rotate(Quaternion rotation)
        {
            Rotation = rotation;
            Rotated?.Invoke();
        }

        private void Move(float acceleration, float deltaTime)
        {
            Position += Rotation * Vector3.forward * acceleration * deltaTime * 6;
            Moved?.Invoke();
        }
    }
}
