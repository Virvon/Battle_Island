using System;
using System.Collections;
using UnityEngine;

namespace Assets.Sources.GameLogic.Learning
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Vector3 _openPosition;
        [SerializeField] private float _animationSpeed;

        public event Action Opened;

        public void Open()
        {
            Opened?.Invoke();

            StartCoroutine(Animator(_animationSpeed));
        }

        private IEnumerator Animator(float speed)
        {
            Vector3 startPosition = transform.position;
            Vector3 targetPosition = transform.position + _openPosition;

            float time = 0;

            while (transform.position != targetPosition)
            {
                time += Time.deltaTime;

                transform.position = Vector3.Lerp(startPosition, targetPosition, time / speed);

                yield return null;
            }
        }
    }
}