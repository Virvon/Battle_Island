using System;
using UnityEngine;

public abstract class DirectionInput : MonoBehaviour
{
    public Vector2 Direction { get; protected set; }

    protected MovementObject Player;

    public abstract event Action Activated;
    public abstract event Action Deactivated;

    public void Init(MovementObject player)
    {
        Player = player;
    }
}
