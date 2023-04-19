using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;

    private MovementObject _target;

    private void OnDisable()
    {
        _target.PositionChanged -= OnTargetPositionChanget;
    }

    public void Init(MovementObject target)
    {
        _target = target;
        _target.PositionChanged += OnTargetPositionChanget;
        OnTargetPositionChanget();
    }

    private void OnTargetPositionChanget()
    {
        transform.position = _target.transform.position + _offset;
    }
}
