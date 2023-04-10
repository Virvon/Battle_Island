using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private JoystickHandler _joystick;

    public event Action<Vector2> InputedRotation;
    public event Action<Vector2> Shooted;
    public event Action Stopped;
    public event Action PositionChanged;

    private void OnEnable()
    {
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

    public void Move(Vector3 position)
    {
        transform.position = position;

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
