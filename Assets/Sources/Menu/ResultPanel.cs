using TMPro;
using UnityEngine;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _place;
    [SerializeField] private LeaderBoard _leaderBoard;
    [SerializeField] private TMP_Text _reward;

    private void OnEnable()
    {
        _place.text = _leaderBoard.FindPlayerPlace().ToString();
        _reward.text = ScoreCounter.Money.ToString();
    }
}
