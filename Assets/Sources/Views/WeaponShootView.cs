using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleIsland.Model;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class WeaponShootView : MonoBehaviour
{
    [SerializeField] private PlayerView _player;

    private Collider _collider;
    private Rigidbody _rigidbody;

    private Coroutine _timer;

    public event Action Shotted;
    public event Action Comebacked;
    public event Action<State> StateChanged; 

    private void OnEnable()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();

        Deactivate();

        _player.Stopped += TryShoot;
    }

    private void OnDisable()
    {
        _player.Stopped -= TryShoot;
    }

    public void Shoot()
    {
        Activate();
        StateChanged?.Invoke(new AttackState());

        _rigidbody.AddForce(transform.forward * 200);

        if (_timer != null)
            StopCoroutine(_timer);

        _timer = StartCoroutine(Timer(3));
    }

    public void Comeback()
    {
        Deactivate();
        StateChanged?.Invoke(new IdleState());
    }

    private void TryShoot()
    {
        Shotted?.Invoke();
    }

    private void TryComeback()
    {
        Comebacked?.Invoke();
    }

    private void Activate()
    {
        _collider.enabled = true;
        _rigidbody.isKinematic = false;
    }

    private void Deactivate()
    {
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
    }

    private IEnumerator Timer(float waitTime)
    {
        bool isFinish = false;

        while (isFinish == false)
        {
            isFinish = true;

            yield return new WaitForSeconds(waitTime);
        }

        TryComeback();
    }
}
