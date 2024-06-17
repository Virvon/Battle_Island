using System;
using System.Collections;
using System.Linq;
using Assets.Sources.GameLogic.FX;
using Assets.Sources.GameLogic.Spawners;
using Assets.Sources.Infrastructure.Views;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Sources.GameLogic.Enemy
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Shield))]
    public class Enemy : MovementObject, IDamageable
    {
        private const int StoppedDistance = 6;
        private const int MinChooseDistance = 15;
        private const int SkinPositionOffsetY = -1;

        private Vector3 _startPoint;
        private Priority.Priority _priority;
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
            _startPoint = transform.position;
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
            _priority = new Priority.Priority(targets.ToList(), this);
            _agent = GetComponent<NavMeshAgent>();
            _targetRadius = pointRadius;
            _shield = GetComponent<Shield>();

            Instantiate(skin, GetSkinPosition(), Quaternion.identity, transform);

            _path = new NavMeshPath();
            _currentTarget = _priority.Choose();

            StartCoroutine(Movement());
        }

        private Vector3 MoveToNearPoint()
        {
            bool isCorrectPoint = false;
            Vector3 target = _currentTarget.transform.position;

            while (isCorrectPoint == false)
            {
                NavMeshHit hit;
                NavMesh.SamplePosition(GetCurrentTargetRadius(), out hit, _targetRadius, NavMesh.AllAreas);

                target = hit.position;

                if (target.magnitude > int.MinValue && target.magnitude < int.MaxValue)
                {
                    _agent.CalculatePath(target, _path);

                    if (_path.status == NavMeshPathStatus.PathComplete && CanCasted(target) == false)
                        isCorrectPoint = true;
                }
            }

            return target;
        }

        private Vector3 GetSkinPosition() =>
            new Vector3(transform.position.x, transform.position.y + SkinPositionOffsetY, transform.position.z);

        private bool CanCasted(Vector3 target) =>
            NavMesh.Raycast(_currentTarget.transform.position, target, out _, NavMesh.AllAreas);

        private Vector3 GetCurrentTargetRadius() =>
            UnityEngine.Random.insideUnitSphere * _targetRadius + _currentTarget.transform.position;

        private bool IsDistanceToTargetMoreTargetRadius(Vector3 targetPoint) =>
            Vector3.Distance(targetPoint, _currentTarget.transform.position) > _targetRadius;

        private IEnumerator Movement()
        {
            Vector3 targetPoint = Vector3.zero;
            bool canMove = true;

            while (canMove)
            {
                if (IsDistanceToTargetMoreTargetRadius(transform.position))
                {
                    if (IsDistanceToTargetMoreTargetRadius(targetPoint) || targetPoint == Vector3.zero)
                        targetPoint = MoveToNearPoint();
                }
                else
                {
                    targetPoint = _currentTarget.transform.position;
                }

                _agent.SetDestination(targetPoint);
                PositionChanged?.Invoke();

                if (_agent.remainingDistance <= StoppedDistance)
                {
                    Stopped?.Invoke();
                    _currentTarget = _priority.ChooseLessPriority();
                }

                var target = _priority.Choose();

                if ((target.transform.position - transform.position).magnitude > MinChooseDistance)
                    _currentTarget = target;

                yield return null;
            }
        }
    }
}