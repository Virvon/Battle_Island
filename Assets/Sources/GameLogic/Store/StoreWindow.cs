using System;
using BattleIsland.UI;
using TMPro;
using Lean.Localization;
using UnityEngine;

namespace BattleIsland.GameLogic.Store
{
    public class StoreWindow : MonoBehaviour
    {
        private const string SelectText = "Select";

        [SerializeField] private Player _player;
        [SerializeField] private Transform _itemPosition;
        [SerializeField] private SelectButton _selectButton;
        [SerializeField] private TMP_Text _price;

        private Item _currentSkinItem;

        public event Action NextItemSetted;
        public event Action PreviousItemSetted;
        public event Action ItemSelected;

        public Player Player => _player;

        public void SetNextItem() =>
            NextItemSetted?.Invoke();

        public void SetPreviousItem() =>
            PreviousItemSetted?.Invoke();

        public void SelectItem() =>
            ItemSelected?.Invoke();

        public void SetItem(Item item)
        {
            if (_currentSkinItem != null)
                _currentSkinItem.Deactivate();

            _currentSkinItem = item;
            item.Activate(_itemPosition.position);
        }

        public void SetButton(bool isChoosed)
        {
            if (isChoosed)
                _selectButton.Activate();
            else
                _selectButton.Deactivate();
        }

        public void SetPrice(Item item)
        {
            if (item.IsBuyed)
                _price.text = LeanLocalization.GetTranslationText(SelectText);
            else
                _price.text = item.Price.ToString();
        }

        public void TryDeactivateItem()
        {
            if (_currentSkinItem != null)
                _currentSkinItem.Deactivate();
        }
    }
}