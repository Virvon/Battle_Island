using System;
using System.Collections;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public event Action<float> TimeChanged;
    public event Action TimeOvered;

    private void Start()
    {
        StartCoroutine(Timer(60, 0.1f));
    }

    private IEnumerator Timer(float delay, float step)
    {
        float StartTime = delay;
        WaitForSeconds waitTime = new WaitForSeconds(step);

        while(StartTime > 0)
        {
            StartTime -= step;

            TimeChanged?.Invoke(StartTime);

            yield return waitTime;
        }

        if (StartTime < 0)
            TimeChanged?.Invoke(0);

        TimeOvered?.Invoke();
    }
}
