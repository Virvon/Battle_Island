using System;
using System.Collections;
using UnityEngine;
using BattleIsland.Model;
using UnityEngine.AI;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class WeaponView : MonoBehaviour
{
    [SerializeField] private PlayerView _player;
    [SerializeField] private Transform _idlePosition;

    public PlayerView Player => _player;
    public Transform IdlePosition => _idlePosition;
    public Rigidbody Rigidbody { get; private set; }

    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Activate()
    {
        _collider.enabled = true;
        Rigidbody.isKinematic = false;
    }

    public void Deactivate()
    {
        _collider.enabled = false;
        Rigidbody.isKinematic = true;
    }
}
