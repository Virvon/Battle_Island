using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleIsland.Input;
using System;

public class DesktopInput : DirectionInput
{
    [SerializeField] private Camera _camera;

    private PlayerInput _input;
    private MovementObject _player;

    public override event Action Activated;
    public override event Action Deactivated;

    private void OnEnable()
    {
        _input = new PlayerInput();
        _input.Enable();

        _input.Player.UpTouch.performed += ctx => OnUpTouh();
    }

    private void OnDisable()
    {
        _input.Disable();

        _input.Player.UpTouch.performed -= ctx => OnUpTouh();
    }

    private void Update()
    {
        if (_input.Player.DownTouch.phase == UnityEngine.InputSystem.InputActionPhase.Performed)
            OnDownTouch();
    }

    private void OnGUI()
    {
        Event currentEvent = Event.current;
        //Vector2 mousePosition = new Vector2();

        //mousePosition.x = currentEvent.mousePosition.x;
        //mousePosition.y = _camera.pixelHeight - currentEvent.mousePosition.y;

        //Vector3 worldPosition = _camera.WorldToScreenPoint(new Vector3(mousePosition.x, mousePosition.y, _camera.nearClipPlane));
        //Vector3 direction = worldPosition - Player.transform.position;

        //Direction = new Vector2(direction.x, direction.y).normalized;

        //---------------------------------------

        Vector2 playerScreenPosition = _camera.WorldToScreenPoint(Player.transform.position);
        Vector2 mousePosition = currentEvent.mousePosition;

        Direction = (mousePosition - playerScreenPosition).normalized;
        Direction = new Vector2(Direction.x, Direction.y * -1);

        //Debug.Log(mousePosition + " | " + playerScreenPosition);
    }

    private void OnDownTouch()
    {
        

        

        if (Direction != Vector2.zero)
            Activated?.Invoke();
    }

    private void OnUpTouh()
    {
        Direction = Vector2.zero;

        Deactivated?.Invoke();
    }
}
