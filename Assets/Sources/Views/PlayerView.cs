using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerView : MonoBehaviour
{
    [SerializeField] private JoystickHandler _joystick;

    private Rigidbody _rigidbody;

    public event Action<Vector2> InputedRotation;
    public event Action<Vector2> Shooted;
    public event Action Stopped;
    public event Action PositionChanged;
    public event Action<Vector3> CollisionEntered;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _joystick.Activated += OnJoystickActivated;
        _joystick.Deactivated += OnJoystickDeactivated;
    }

    private void OnDisable()
    {
        _joystick.Activated -= OnJoystickActivated;
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
