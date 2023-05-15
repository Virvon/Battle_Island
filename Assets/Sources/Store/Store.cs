using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private StoreView _view;

    private const string SaveKey = "StoreSaveKey";

    private List<Item> _items;
    private Item _currentItem;
    private Item _selectItem;

    public static GameObject SelectSkin { get; private set; }

    private void Start()
    {
        _items = GetComponentsInChildren<Item>().ToList();


        _view.NextItemSetted += OnNextItemSetted;
        _view.PreviousItemSetted += OnPreviousItemSetted;
        _view.ItemSelected += OnItemSelected;

        _selectItem = Load(SaveKey);

        if (_selectItem == null || _selectItem.IsBuyed == false)
            _selectItem = _items.Where(item => item.IsBuyed).First();

        _currentItem = _selectItem;


        SetItem(_currentItem, _view);
    }

    private void OnDisable()
    {
        _view.NextItemSetted -= OnNextItemSetted;
        _view.PreviousItemSetted -= OnPreviousItemSetted;
        _view.ItemSelected -= OnItemSelected;

        SelectSkin = _selectItem.Skin;
    }

    private void OnNextItemSetted()
    {
        var currentItemIndex = _items.IndexOf(_currentItem);

        _currentItem = currentItemIndex + 1 < _items.Count  ? _items[currentItemIndex + 1] : _items.First();

        SetItem(_currentItem, _view);
    }

    private void OnPreviousItemSetted()
    {
        var currentItemIndex = _items.IndexOf(_currentItem);

        _currentItem = currentItemIndex - 1 >= 0 ? _items[currentItemIndex - 1] : _items.Last();

        SetItem(_currentItem, _view);
    }

    private void OnItemSelected()
    {
        if(_currentItem.TrySecelct(_view.Player))
        {
            _selectItem = _currentItem;
            _view.SetButton(_currentItem == _selectItem);
            _view.SetPrice(_currentItem);

            Save(SaveKey);
        }
    }

    private void SetItem(Item item, StoreView view)
    {
        view.SetItem(item);
        view.SetButton(_currentItem == _selectItem);
        view.SetPrice(item);
    }

    private void Save(string key)
    {
        SaveManger.Save(key, CreateSavesnapshot());
    }

    private Item Load(string key)
    {
        StoreProfile data = SaveManger.Load<StoreProfile>(key);

        return data.SelectItem;
    }

    private StoreProfile CreateSavesnapshot()
    {
        StoreProfile data = new()
        {
            SelectItem = _selectItem
        };

        return data;
    }
}
