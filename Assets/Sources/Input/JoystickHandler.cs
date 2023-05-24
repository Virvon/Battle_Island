using System;
using UnityEngine;
using UnityEngine.EventSystems;
using BattleIsland.Input;

public class JoystickHandler : DirectionInput, IDragHandler
{
    [SerializeField] private RectTransform _handleSlideArea;
    [SerializeField] private RectTransform _handle;

    private PlayerInput _input;

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

    public void OnDrag(PointerEventData eventData)
    {
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(_handleSlideArea, eventData.position, null, out Vector2 joystickPosition))
        {
            joystickPosition.x = (joystickPosition.x * (2 / _handleSlideArea.sizeDelta.x));
            joystickPosition.y = (joystickPosition.y * (2 / _handleSlideArea.sizeDelta.y));

            Direction = joystickPosition;

            if (Direction.magnitude > 1)
                Direction = Direction.normalized;

            _handle.anchoredPosition = new Vector2(Direction.x * (_handleSlideArea.sizeDelta.x / 2), Direction.y * (_handleSlideArea.sizeDelta.y / 2));
        }
    }

    private void OnDownTouch()
    {
        if(Direction != Vector2.zero)
            Activated?.Invoke();
    }

    private void OnUpTouh()
    {
        _handle.anchoredPosition = Vector3.zero;
        Direction = Vector2.zero;

        Deactivated?.Invoke();
    }
}
