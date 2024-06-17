using System;
using BattleIsland.Infrastructure.View.Weapon;
using UnityEngine;

namespace BattleIsland.GameLogic.Obstacle
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private bool _isDamagable;
        [SerializeField] private int _health;

        private bool _isBroking;

        public event Action Broked;
        public event Action Hited;

        private void Start() =>
            _isBroking = false;

        private void OnCollisionEnter(Collision collision)
        {
            if (_isDamagable == false)
                return;

            if (collision.collider.TryGetComponent(out WeaponView weapon))
            {
                _health--;

                if (_health > 0)
                {
                    Hited?.Invoke();
                }
                else if (_isBroking == false)
                {
                    _isBroking = true;
                    _health = 0;
                    Broked?.Invoke();
                }
            }
        }
    }
}