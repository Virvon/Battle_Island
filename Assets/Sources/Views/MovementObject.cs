using System;
using UnityEngine;

public abstract class MovementObject : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;

    public int MurdersCount { get; private set; }

    public string Name { get; protected set; }

    public Transform ShootPoint => _shootPoint;

    public event Action MurdersCountChanged;

    public abstract event Action PositionChanged;
    public abstract event Action Stopped;
    public abstract event Action Died;

    public void TakeMurder()
    {
        MurdersCount++;
        MurdersCountChanged?.Invoke();
    }
}
