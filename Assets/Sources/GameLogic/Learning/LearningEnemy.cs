using System;
using Assets.Sources.Animation;
using Assets.Sources.Infrastructure.Views;
using UnityEngine;

namespace Assets.Sources.GameLogic.Learning
{
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
            _animator.SetTrigger(AnimationPath.LearningEnemy.Died);
            Destroyed?.Invoke();
        }
    }
}