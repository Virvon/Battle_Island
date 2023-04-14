using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyView : MovementObject, IDamageable
{
    private MovementObject _currentTarget;
    private NavMeshAgent _agent;
    private Priority _priority;
    private Coroutine _coroutine;
    private Vector3 _spawnPoint;

    public event Action TargetChoosed;
    public event Action DamageTaked;

    public override event Action PositionChanged;
    public override event Action Stopped;

    public void Init(MovementObject[] targets)
    {
        _agent = GetComponent<NavMeshAgent>();
        _priority = new Priority(targets.ToList());
        _spawnPoint = transform.position;

        StartCoroutine(TargetChanger());
        TargetChoosed?.Invoke();
    }

    public void MoveToTarget()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        if (_currentTarget != null && (_currentTarget.transform.position - transform.position).magnitude > _agent.stoppingDistance)
            _coroutine = StartCoroutine(Follower(_currentTarget));
        else
            _agent.destination = new Vector3(UnityEngine.Random.Range(-20, 20), 0, UnityEngine.Random.Range(-20, 20));
    }

    public void TakeDamage()
    {
        DamageTaked?.Invoke();
    }

    public void Respawn()
    {
        transform.position = _spawnPoint;

        _currentTarget = _priority.Choose(this);

        TargetChoosed?.Invoke();
        PositionChanged?.Invoke();
    }

    private IEnumerator Follower(MovementObject target)
    {
        float distance = UnityEngine.Random.Range(_agent.stoppingDistance, _agent.stoppingDistance * 1.5f);

        while ((transform.position - target.transform.position).magnitude > distance)
        {
            _agent.destination = target.transform.position;
            PositionChanged?.Invoke();

            yield return null;
        }

        Quaternion rotation = Quaternion.Euler(((transform.position - target.transform.position) * UnityEngine.Random.Range(0.6f, 1.4f)).normalized);

        transform.rotation = rotation;

        Stopped?.Invoke();
        _currentTarget = _priority.Choose(this);
        TargetChoosed?.Invoke();
    }

    private IEnumerator TargetChanger()
    {
        while (1 == 2)
        {
            _currentTarget = _priority.Choose(this);
            TargetChoosed?.Invoke();

            yield return new WaitForSeconds(2);
        }
    }
}
