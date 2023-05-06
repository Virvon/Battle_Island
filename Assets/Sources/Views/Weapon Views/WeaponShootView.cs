using System;
using System.Collections;
using UnityEngine;
using BattleIsland.Model;
using UnityEngine.AI;

[RequireComponent(typeof(WeaponView), typeof(NavMeshAgent), typeof(WeaponAudio))]
public class WeaponShootView : MonoBehaviour
{
    private Coroutine _coroutine;
    private NavMeshAgent _agent;
    private WeaponView _weaponView;

    private WeaponAnimationsController _animationsController;
    private ParticlesController _particlesController;
    private WeaponAudio _weaponAudio;

    public event Action Shotted;
    public event Action Comebacked;
    public event Action<State> StateChanged;
    public event Action<Vector3, Vector3> CollisionEntered;

    private void OnEnable()
    {
        _weaponView = GetComponent<WeaponView>();
        _agent = GetComponent<NavMeshAgent>();

        _particlesController = GetComponentInChildren<ParticlesController>();
        _animationsController = GetComponentInChildren<WeaponAnimationsController>();
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

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Let let) || collision.collider.TryGetComponent(out WeaponView weapon))
            CollisionEntered?.Invoke(transform.rotation * Vector3.forward, collision.contacts[0].normal);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable iDamageble))
        {
            if ((object)iDamageble != _weaponView.Parent)
            {
                iDamageble.TakeDamage();
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
        _particlesController.Activate();
        _weaponAudio.PlayShootAudio();

        _weaponView.Rigidbody.AddForce(transform.forward * 1100);
        

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ComebackTimer());
    }

    public void Comeback()
    {
        _agent.enabled = true;
        _weaponView.Deactivate();

        if(_coroutine!= null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeStateTimer(new IdleState()));
    }

    public void ChangeTrajectory(Vector3 direction)
    {
        _weaponView.Rigidbody.AddForce(direction * 600);
    }

    private void TryShoot()
    {
        Shotted?.Invoke();
    }

    private void TryComeback()
    {
        Comebacked?.Invoke();
    }

    private void OnInited()
    {
        _weaponView.Parent.Stopped += TryShoot;
    }

    private IEnumerator ComebackTimer()
    {
        do
        {
            yield return new WaitForSeconds(0.1f);
        } while (_weaponView.Rigidbody.velocity.magnitude > 1.5f);

        TryComeback();
    }

    private IEnumerator ChangeStateTimer(State state) 
    {
        while ((transform.position - _weaponView.IdlePosition.position).magnitude > 0.5f)
        {
            _agent.destination = _weaponView.IdlePosition.position;

            yield return null;
        }

        StateChanged?.Invoke(state);

        _animationsController.ComeBack();
        _particlesController.Deactivate();

        _agent.enabled = false;
    }
}
