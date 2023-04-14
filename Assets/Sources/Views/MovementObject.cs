using System;
using UnityEngine;

public abstract class MovementObject : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;

    public Transform ShootPoint => _shootPoint;

    public abstract event Action PositionChanged;
    public abstract event Action Stopped;
}
