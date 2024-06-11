using System;
using UnityEngine;

namespace BattleIsland.GameLogic.Learning
{
    public class EnemiesDestroyedTrigger : MonoBehaviour, ITriggerable
    {
        [SerializeField] private LearningEnemy[] _enemies;

        private float _letsCount;

        public event Action Triggered;

        private void OnEnable()
        {
            _letsCount = _enemies.Length;

            foreach (var enemy in _enemies)
                enemy.Destroyed += OnBroked;
        }

        private void OnDisable()
        {
            foreach (var enemy in _enemies)
                enemy.Destroyed -= OnBroked;
        }

        private void OnBroked()
        {
            _letsCount--;

            if (_letsCount <= 0)
                Triggered?.Invoke();
        }
    }
}