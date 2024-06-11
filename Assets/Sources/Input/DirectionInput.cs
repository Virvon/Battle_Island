using System;
using BattleIsland.Infrastructure.View;
using UnityEngine;

namespace BattleIsland.Input
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