using TMPro;
using UnityEngine;
using System;

public class TimerView : MonoBehaviour
{
    [SerializeField] private GameTimer _game;
    [SerializeField] private TMP_Text _time;

    private void OnEnable()
    {
        _game.TimeChanged += OnTimeChanged;
    }

    private void OnDisable()
    {
        _game.TimeChanged -= OnTimeChanged;
    }

    private void OnTimeChanged(float time)
    {
        _time.text = Math.Round(time, 1, MidpointRounding.AwayFromZero).ToString();
    }
}
