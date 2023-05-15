using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private GameTimer _timer;
    [SerializeField] private LeaderBoard _leaderBoard;

    public static int Money { get; private set; }

    private void OnEnable()
    {
        _timer.TimeOvered += AddScore;
    }

    private void OnDisable()
    {
        _timer.TimeOvered -= AddScore;
    }

    private void AddScore()
    {
        Money = 100 / _leaderBoard.FindPlayerPlace();
    }
}
