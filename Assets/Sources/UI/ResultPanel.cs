using TMPro;
using UnityEngine;

namespace BattleIsland.UI
{
    public class ResultPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _place;
        [SerializeField] private LeaderBoard _leaderBoard;
        [SerializeField] private TMP_Text _reward;

        private void OnEnable()
        {
            _place.text = _leaderBoard.GetPlayerPlace().ToString();
            _reward.text = ScoreCounter.Money.ToString();
        }
    }
}