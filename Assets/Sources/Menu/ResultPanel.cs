using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _place;
    [SerializeField] private LeaderBoard _leaderBoard;

    private void OnEnable()
    {
        _place.text = _leaderBoard.FindPlayerPlace().ToString();
    }
}
