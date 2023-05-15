using System;
using TMPro;
using UnityEngine;
using BattleIsland.Menu;
using Lean.Localization;

public class StoreView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _itemPosition;
    [SerializeField] private SelectButton _selectButton;
    [SerializeField] private TMP_Text _price;

    public Player Player => _player;

    private Item _currentItem;

    public event Action NextItemSetted;
    public event Action PreviousItemSetted;
    public event Action ItemSelected;

    public void SetNextItem()
    {
        NextItemSetted?.Invoke();
    }

    public void SetPreviousItem()
    {
        PreviousItemSetted?.Invoke();
    }

    public void SelectItem()
    {
        ItemSelected?.Invoke();
    }

    public void SetItem(Item item)
    {
        if (_currentItem != null)
            _currentItem.Deactivate();

        _currentItem = item;
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
            _price.text = LeanLocalization.GetTranslationText("Select");
        else
            _price.text = item.Price.ToString();
    }
}
