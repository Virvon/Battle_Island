using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Shield))]
public class PlayerView : MovementObject, IDamageable
{
    private JoystickHandler _joystick;
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
        _joystick.Activated -= OnJoystickActivated;
        _joystick.Deactivated += OnJoystickDeactivated;
    }
    public void Init(JoystickHandler joystick)
    {
        Name = "You";

        _joystick = joystick;
        _spawnPoint = transform.position;

        _rigidbody = GetComponent<Rigidbody>();
        _shield = GetComponent<Shield>();

        _joystick.Activated += OnJoystickActivated;
        _joystick.Deactivated += OnJoystickDeactivated;
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
        InputedRotation?.Invoke(_joystick.Output);
    }

    private void OnJoystickDeactivated()
    {
        Shooted?.Invoke(transform.rotation * Vector3.forward);
        Stopped?.Invoke();
    }
}
