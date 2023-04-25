using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementObject))]
public class AnimaionsController : MonoBehaviour
{
    private Animator _animator;
    private MovementObject _unit;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _unit = GetComponent<MovementObject>();

        _unit.PositionChanged += OnPositionChanged;
        _unit.Stopped += OnStopped;
    }

    private void OnDisable()
    {
        _unit.PositionChanged -= OnPositionChanged;
        _unit.Stopped -= OnStopped;
    }

    private void OnPositionChanged()
    {
        _animator.SetBool("IsRun", true);
    }

    private void OnStopped()
    {
        _animator.SetTrigger("Attack");
        _animator.SetBool("IsRun", false);
    }
}
