using System;
using System.Collections;
using UnityEngine;

namespace BattleIsland.UI
{
    public class GameTimer : MonoBehaviour
    {
        private const int GameDuration = 60;
        private const float TimerStep = 0.1f;

        public event Action<float> TimeChanged;
        public event Action TimeOvered;

        private void Start()
        {
            StartCoroutine(Timer(GameDuration, TimerStep));
        }

        private IEnumerator Timer(float delay, float step)
        {
            float timeLeft = delay;
            WaitForSeconds waitTime = new WaitForSeconds(step);

            while (timeLeft > 0)
            {
                timeLeft -= step;

                TimeChanged?.Invoke(timeLeft);

                yield return waitTime;
            }

            if (timeLeft < 0)
                TimeChanged?.Invoke(0);

            TimeOvered?.Invoke();
        }
    }
}