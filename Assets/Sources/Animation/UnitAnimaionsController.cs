using UnityEngine;

[RequireComponent(typeof(MovementObject))]
public class UnitAnimaionsController : MonoBehaviour
{
    private Animator _animator;
    private MovementObject _unit;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _unit = GetComponent<MovementObject>();

        _unit.PositionChanged += OnPositionChanged;
        _unit.Stopped += OnStopped;
        _unit.Died += OnDied;
    }

    private void OnDisable()
    {
        _unit.PositionChanged -= OnPositionChanged;
        _unit.Stopped -= OnStopped;
        _unit.Died -= OnDied;
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

    private void OnDied()
    {
        _animator.SetBool("IsRun", false);
    }
}
