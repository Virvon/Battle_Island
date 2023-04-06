using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickHandler : MonoBehaviour, IDragHandler
{
    [SerializeField] private RectTransform _handleSlideArea;
    [SerializeField] private RectTransform _handle;

    private Vector2 _input;

    public void OnDrag(PointerEventData eventData)
    {
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(_handleSlideArea, eventData.position, null, out Vector2 joystickPosition))
        {
            joystickPosition.x = (joystickPosition.x * (2 / _handleSlideArea.sizeDelta.x));
            joystickPosition.y = (joystickPosition.y * (2 / _handleSlideArea.sizeDelta.y));

            _input = joystickPosition;

            if (_input.magnitude > 1)
                _input = _input.normalized;

            _handle.anchoredPosition = new Vector2(_input.x * (_handleSlideArea.sizeDelta.x / 2), _input.y * (_handleSlideArea.sizeDelta.y / 2));

            Debug.Log(_input);
        }
    }
}
