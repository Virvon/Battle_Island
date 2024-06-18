using System;
using System.Collections;
using Assets.Sources.Animation;
using Assets.Sources.Audio;
using Assets.Sources.GameLogic.FX;
using Assets.Sources.GameLogic.Obstacle;
using Assets.Sources.Infrastructure.Models;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Sources.Infrastructure.Views.Weapon
{
    [RequireComponent(typeof(WeaponView), typeof(NavMeshAgent), typeof(WeaponAudio))]
    public class WeaponShootView : MonoBehaviour
    {
        private const float ShootForce = 1350;
        private const float Delay = 0.1f;
        private const float MinDistance = 3.8f;
        private const float MaxDistance = 0.5f;
        private Coroutine _coroutine;
        private NavMeshAgent _agent;
        private WeaponView _weaponView;

        private WeaponAnimations _animationsController;
        private Particle _particle;
        private WeaponAudio _weaponAudio;

        public event Action Shotted;
        public event Action Comebacked;
        public event Action<State> StateChanged;
        public event Action<Vector3, Vector3> CollisionEntered;

        private float HalfShootForse => ShootForce / 2;

        private void OnEnable()
        {
            _weaponView = GetComponent<WeaponView>();
            _agent = GetComponent<NavMeshAgent>();

            _particle = GetComponentInChildren<Particle>();
            _animationsController = GetComponentInChildren<WeaponAnimations>();
            _weaponAudio = GetComponent<WeaponAudio>();

            _weaponView.Inited += OnInited;
        }

        private void Start()
        {
            _weaponView.Deactivate();
            _agent.enabled = false;
        }

        private void OnDisable()
        {
            _weaponView.Inited -= OnInited;
            _weaponView.Parent.Stopped -= TryShoot;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Obstacle let)
                || collision.collider.TryGetComponent(out WeaponView weapon))
                CollisionEntered?.Invoke(transform.rotation * Vector3.forward, collision.contacts[0].normal);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageable damageble))
            {
                if ((MonoBehaviour)damageble != _weaponView.Parent)
                {
                    damageble.TakeDamage();
                    _weaponView.Parent.TakeMurder();

                    _weaponAudio.PlayHitAudio();
                }
            }
        }

        public void Shoot()
        {
            _agent.enabled = false;
            _weaponView.Activate();
            StateChanged?.Invoke(new AttackState());

            _animationsController.Shoot();
            _particle.Activate();
            _weaponAudio.PlayShootAudio();

            _weaponView.Rigidbody.AddForce(transform.forward * ShootForce);

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(ComebackTimer());
        }

        public void Comeback()
        {
            _agent.enabled = true;
            _weaponView.Deactivate();

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(ChangeStateTimer(new IdleState()));
        }

        public void ChangeTrajectory(Vector3 direction) =>
            _weaponView.Rigidbody.AddForce(direction * HalfShootForse);

        private void TryShoot() =>
            Shotted?.Invoke();

        private void TryComeback() =>
            Comebacked?.Invoke();

        private void OnInited() =>
            _weaponView.Parent.Stopped += TryShoot;

        private IEnumerator ComebackTimer()
        {
            WaitForSeconds delay = new WaitForSeconds(Delay);

            do
            {
                yield return delay;
            }
            while (_weaponView.Rigidbody.velocity.magnitude > MinDistance);

            TryComeback();
        }

        private IEnumerator ChangeStateTimer(State state)
        {
            while ((transform.position - _weaponView.IdlePosition.position).magnitude > MaxDistance)
            {
                _agent.destination = _weaponView.IdlePosition.position;

                yield return null;
            }

            StateChanged?.Invoke(state);

            _animationsController.ComeBack();
            _particle.Deactivate();

            _agent.enabled = false;
        }
    }
}