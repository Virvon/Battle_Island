using System;
using System.Collections;
using UnityEngine;

public class Let : MonoBehaviour
{
    [SerializeField] private int _health;

    private bool _isStatic;

    public event Action Broked;
    public event Action Hited;

    private void Start()
    {
        _isStatic = gameObject.isStatic;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isStatic)
            return;

        if(collision.collider.TryGetComponent(out WeaponView weapon))
        {
            _health--;

            if (_health > 0)
                Hited?.Invoke();
            else
                Broked?.Invoke();
        }
    }
}
