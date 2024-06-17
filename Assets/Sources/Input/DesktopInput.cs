using System;
using UnityEngine;
using UnityEngine.InputSystem;
using PlayerInput = BattleIsland.Input.PlayerInput;

namespace Assets.Sources.Input
{
    public class DesktopInput : DirectionInput
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Vector2 _offset;

        private PlayerInput _input;

        public override event Action Activated;
        public override event Action Deactivated;

        private void OnEnable()
        {
            _input = new PlayerInput();
            _input.Enable();

            _input.Player.UpTouch.performed += OnUpTouchPerformed;
        }

        private void OnDisable()
        {
            _input.Disable();

            _input.Player.UpTouch.performed -= OnUpTouchPerformed;
        }

        private void Update()
        {
            if (_input.Player.DownTouch.phase == InputActionPhase.Performed)
                OnDownTouch();
        }

        private void OnGUI()
        {
            Event currentEvent = Event.current;

            Vector2 playerScreenPosition = _camera.WorldToScreenPoint(Player.transform.position);
            Vector2 mousePosition = currentEvent.mousePosition;

            Direction = (mousePosition - playerScreenPosition + _offset).normalized;
            Direction = new Vector2(Direction.x, Direction.y * -1);
        }

        private void OnDownTouch()
        {
            if (Direction != Vector2.zero)
                Activated?.Invoke();
        }

        private void OnUpTouchPerformed(InputAction.CallbackContext _) =>
            OnUpTouh();

        private void OnUpTouh()
        {
            Direction = Vector2.zero;

            Deactivated?.Invoke();
        }
    }
}