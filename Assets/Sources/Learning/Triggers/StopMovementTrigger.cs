using System;
using UnityEngine;

public class StopMovementTrigger : MonoBehaviour, ITriggerable
{
    [SerializeField] private DirectionInput _directionInput;

    public event Action Triggered;

    private void OnEnable() => _directionInput.Deactivated += OnActivated;

    private void OnDisable() => _directionInput.Deactivated -= OnActivated;

    private void OnActivated() => Triggered?.Invoke();
}
