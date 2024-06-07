using System;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Collider))]
public class LearningEnemy : MonoBehaviour, IDamageable
{
    private Animator _animator;
    private Collider _collider;

    public event Action Destroyed;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();
    }

    public void TakeDamage()
    {
        _collider.enabled = false;
        _animator.SetTrigger("Died");
        Destroyed?.Invoke();
    }
}
