using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleIsland.SaveData;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public event Action<float> TimeChanged;
    public event Action TimeOvered;

    private void Start()
    {
        StartCoroutine(Timer(30, 0.1f));
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

        TimeOvered?.Invoke();
    }
}
