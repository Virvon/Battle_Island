using TMPro;
using UnityEngine;

namespace BattleIsland.UI
{
    public class WalletWindow : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private TMP_Text _money;

        private void OnEnable() =>
            _player.MoneyCountChanged += OnMoneyCountChanged;

        private void OnDisable() =>
            _player.MoneyCountChanged -= OnMoneyCountChanged;

        private void OnMoneyCountChanged() =>
            _money.text = _player.Money.ToString();
    }
}