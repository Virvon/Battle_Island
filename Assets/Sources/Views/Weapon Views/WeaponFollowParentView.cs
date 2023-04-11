using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponView))]
public class WeaponFollowParentView : MonoBehaviour
{
    private WeaponView _weaponView;

    public event Action PlayerPositionChanged;

    public void OnEnable()
    {
        _weaponView = GetComponent<WeaponView>();

        _weaponView.Player.PositionChanged += OnPlayerPositionChanged;
    }

    public void OnDisable()
    {
        _weaponView.Player.PositionChanged -= OnPlayerPositionChanged;
    }

    public void ChangePosition()
    {
        transform.position = _weaponView.IdlePosition.position;
        transform.rotation = _weaponView.Player.transform.rotation;
    }

    private void OnPlayerPositionChanged()
    {
        PlayerPositionChanged?.Invoke();
    }
}
