using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private JoystickHandler _joystick;

    public event Action<Vector2> InputedRotation;

    private void OnEnable()
    {
        _joystick.Activated += OnJoysticActivated;
    }

    private void OnDisable()
    {
        _joystick.Activated -= OnJoysticActivated;
    }

    public void Rotate(Quaternion rotation)
    {
        transform.rotation = rotation;
    }

    public void Move(Vector3 position)
    {
        transform.position = position;
    }

    private void OnJoysticActivated()
    {
        InputedRotation?.Invoke(_joystick.Output);
    }
}
