using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyView : MovementObject, IDamageable
{
    private Vector3 _startPoint;
    private Priority _priority;
    private MovementObject _currentTarget;
    private NavMeshAgent _agent;

    public override event Action PositionChanged;
    public override event Action Stopped;

    private void Update()
    {
        _currentTarget = _priority.Choose(this);

        if (_currentTarget != null)
            _agent.destination = _currentTarget.transform.position;
        else
        {
            _agent.destination = _startPoint;
            return;
        }

        if((transform.position - _currentTarget.transform.position).magnitude <= _agent.stoppingDistance)
        {
            Stopped?.Invoke();
        }
    }

    public void TakeDamage()
    {
        transform.position = _startPoint;
    }

    public void Init(MovementObject[] targets)
    {
        _priority = new Priority(targets.ToList());
        _startPoint = transform.position;
        _agent = GetComponent<NavMeshAgent>();
    }
}
