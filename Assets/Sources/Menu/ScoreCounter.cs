using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private GameTimer _timer;
    [SerializeField] private LeaderBoard _leaderBoard;

    public static int Money { get; private set; }

    private void OnEnable()
    {
        _timer.TimeOvered += AddScore;
        Advertisement.Rewarded += OnRewarded;
    }

    private void OnDisable()
    {
        _timer.TimeOvered -= AddScore;
        Advertisement.Rewarded -= OnRewarded;
    }

    private void AddScore()
    {
        Money = 100 / _leaderBoard.GetPlayerPlace();
    }

    private void OnRewarded()
    {
        Money *= 3;
    }
}
