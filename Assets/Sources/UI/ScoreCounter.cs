using UnityEngine;

namespace BattleIsland.UI
{
    public class ScoreCounter : MonoBehaviour
    {
        private const int RewardMultiplier = 3;
        private const int MaxReward = 100;

        [SerializeField] private GameTimer _timer;
        [SerializeField] private LeaderBoard _leaderBoard;

        public static int Money { get; private set; }

        private void OnEnable()
        {
            _timer.TimeOvered += AddScore;
            Advertisement.Advertisement.Rewarded += OnRewarded;
        }

        private void OnDisable()
        {
            _timer.TimeOvered -= AddScore;
            Advertisement.Advertisement.Rewarded -= OnRewarded;
        }

        private void AddScore() =>
            Money = MaxReward / _leaderBoard.GetPlayerPlace();

        private void OnRewarded() =>
            Money *= RewardMultiplier;
    }
}