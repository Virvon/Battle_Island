using System;
using UnityEngine;

public class PositionTrigger : MonoBehaviour, ITriggerable
{
    [SerializeField] private SpatialTrigger _spatialTrigger;

    public event Action Triggered;

    private void OnEnable() => _spatialTrigger.PlayerEntered += OnPlayerEntered;

    private void OnDisable() => _spatialTrigger.PlayerEntered -= OnPlayerEntered;

    private void OnPlayerEntered()
    {
        Triggered?.Invoke();
        gameObject.SetActive(false);
    }
}
