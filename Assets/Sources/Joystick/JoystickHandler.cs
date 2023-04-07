using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using BattleIsland.Input;

public class JoystickHandler : MonoBehaviour, IDragHandler
{
    [SerializeField] private RectTransform _handleSlideArea;
    [SerializeField] private RectTransform _handle;

    public Vector2 Output { get; private set; }

    private PlayerInput _input;

    public event Action Activated;

    private void OnEnable()
    {
        _input = new PlayerInput();
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        if (_input.Player.Tap.phase == UnityEngine.InputSystem.InputActionPhase.Performed)
            OnTap();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(_handleSlideArea, eventData.position, null, out Vector2 joystickPosition))
        {
            joystickPosition.x = (joystickPosition.x * (2 / _handleSlideArea.sizeDelta.x));
            joystickPosition.y = (joystickPosition.y * (2 / _handleSlideArea.sizeDelta.y));

            Output = joystickPosition;

            if (Output.magnitude > 1)
                Output = Output.normalized;

            _handle.anchoredPosition = new Vector2(Output.x * (_handleSlideArea.sizeDelta.x / 2), Output.y * (_handleSlideArea.sizeDelta.y / 2));
        }
    }

    private void OnTap()
    {
        Debug.Log(Output);

        if(Output != Vector2.zero)
            Activated?.Invoke();
    }
}
