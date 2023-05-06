using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Shield))]
public class Enemy : MovementObject, IDamageable
{
    private Vector3 _startPoint;
    private Priority _priority;
    private MovementObject _currentTarget;
    private NavMeshAgent _agent;
    private float _targetRadius;
    private NavMeshPath _path;
    private Shield _shield;

    public override event Action PositionChanged; 
    public override event Action Stopped;
    public override event Action Died;

    private void Awake()
    {
        Name = NamesGenerator.GetName();
    }

    public void TakeDamage()
    {
        if (_shield.IsActive)
            return;

        Died?.Invoke();
        transform.position = _startPoint;
        PositionChanged?.Invoke();
        _shield.Activate();
    }

    public void Init(MovementObject[] targets, GameObject skin, float pointRadius)
    {
        _priority = new Priority(targets.ToList(), this);
        _startPoint = transform.position;
        _agent = GetComponent<NavMeshAgent>();
        _targetRadius = pointRadius;
        _shield = GetComponent<Shield>();

        Instantiate(skin, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity, transform);

        _path = new NavMeshPath();
        _currentTarget = _priority.Choose();

        StartCoroutine(Movement());
    }

    private Vector3 MoveToNearPoint()
    {
        bool isCorrectPoint = false;
        Vector3 target = _currentTarget.transform.position;

        while(isCorrectPoint == false)
        {
            NavMeshHit hit;
            NavMesh.SamplePosition(UnityEngine.Random.insideUnitSphere * _targetRadius + _currentTarget.transform.position, out hit, _targetRadius, NavMesh.AllAreas);

            target = hit.position;

            if(target.magnitude > int.MinValue && target.magnitude < int.MaxValue)
            {
                _agent.CalculatePath(target, _path);

                if(_path.status == NavMeshPathStatus.PathComplete && NavMesh.Raycast(_currentTarget.transform.position, target, out hit, NavMesh.AllAreas) == false)
                    isCorrectPoint = true;
            }
        }

        return target;
    }

    private IEnumerator Movement()
    {
        Vector3 targetPoint = Vector3.zero;

        while (true)
        {
            if (Vector3.Distance(transform.position, _currentTarget.transform.position) > _targetRadius)
            {
                if(Vector3.Distance(targetPoint, _currentTarget.transform.position) > _targetRadius || targetPoint == Vector3.zero)
                    targetPoint = MoveToNearPoint();
            }
            else
            {
                targetPoint = _currentTarget.transform.position;
            }

            _agent.SetDestination(targetPoint);
            PositionChanged?.Invoke();

            if (_agent.remainingDistance <= 6)
            {
                Stopped?.Invoke();
                _currentTarget = _priority.ChooseLessPriority();
            }

            var target = _priority.Choose();

            if((target.transform.position - transform.position).magnitude > 15)
                _currentTarget = target;

            yield return null;
        }
    }
}
