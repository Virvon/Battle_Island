using System;
using UnityEngine;

public abstract class MovementObject : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;

    public int MurdersCount { get; private set; }

    public Transform ShootPoint => _shootPoint;

    public event Action MurdersCountChanged;

    public abstract event Action PositionChanged;
    public abstract event Action Stopped;

    public void TakeMurder()
    {
        MurdersCount++;
        MurdersCountChanged?.Invoke();
    }
}
