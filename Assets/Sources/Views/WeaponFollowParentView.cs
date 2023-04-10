using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollowParentView : MonoBehaviour
{
    [SerializeField] private PlayerView _player;
    [SerializeField] private Transform _idlePosition;

    public event Action PlayerPositionChanged;

    public void OnEnable()
    {
        _player.PositionChanged += OnPlayerPositionChanged;
    }

    public void OnDisable()
    {
        _player.PositionChanged -= OnPlayerPositionChanged;
    }

    public void ChangePosition()
    {
        transform.position = _idlePosition.position;
        transform.rotation = _player.transform.rotation;
    }

    private void OnPlayerPositionChanged()
    {
        PlayerPositionChanged?.Invoke();
    }
}
