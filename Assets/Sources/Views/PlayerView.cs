using Lean.Localization;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Shield))]
public class PlayerView : MovementObject, IDamageable
{
    private DirectionInput _input;
    private Rigidbody _rigidbody;
    private Vector3 _spawnPoint;
    private Shield _shield;

    public event Action<Vector2> InputedRotation;
    public event Action<Vector2> Shooted;

    public override event Action PositionChanged;
    public override event Action Stopped;
    public override event Action Died;

    private void OnDisable()
    {
        _input.Activated -= OnJoystickActivated;
        _input.Deactivated += OnJoystickDeactivated;
    }
    public void Init(DirectionInput directionInput)
    {
        switch (LeanLocalization.GetFirstCurrentLanguage())
        {
            case "Russian":
                Name = "Ты";
                break;
            case "English":
                Name = "You";
                break;
            case "Turkiye":
                Name = "Sen";
                break;
        }

        _input = directionInput;
        _spawnPoint = transform.position;

        _rigidbody = GetComponent<Rigidbody>();
        _shield = GetComponent<Shield>();

        _input.Activated += OnJoystickActivated;
        _input.Deactivated += OnJoystickDeactivated;
    }

    public void Rotate(Quaternion rotation)
    {
        transform.rotation = rotation;
    }

    public void Move(Vector3 velocity)
    {
        _rigidbody.velocity = velocity;

        PositionChanged?.Invoke();
    }

    public void Respawn()
    {
        Died?.Invoke();

        transform.position = _spawnPoint;

        PositionChanged?.Invoke();

        _shield.Activate();
    }

    public void TakeDamage()
    {
        if(_shield.IsActive == false)
            Respawn();
    }

    private void OnJoystickActivated()
    {
        InputedRotation?.Invoke(_input.Direction);
    }

    private void OnJoystickDeactivated()
    {
        Shooted?.Invoke(transform.rotation * Vector3.forward);
        Stopped?.Invoke();
    }
}
