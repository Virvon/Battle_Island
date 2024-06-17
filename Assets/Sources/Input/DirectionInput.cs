using System;
using Assets.Sources.Infrastructure.Views;
using UnityEngine;

namespace Assets.Sources.Input
{
    public abstract class DirectionInput : MonoBehaviour
    {
        public abstract event Action Activated;
        public abstract event Action Deactivated;

        public Vector2 Direction { get; protected set; }
        protected MovementObject Player { get; private set; }

        public void Init(MovementObject player) =>
            Player = player;
    }
}