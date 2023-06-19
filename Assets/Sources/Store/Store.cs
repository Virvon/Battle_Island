using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Store : MonoBehaviour
{
    [SerializeField] private StoreView _view;
    [SerializeField] private Item _defaultItem;
    [SerializeField] private string SaveKey;

    private Item _currentItem;

    protected List<Item> Items;
    protected Item _selectItem;

    private void OnEnable()
    {
        Items = GetComponentsInChildren<Item>().ToList();

        SetSelectItem(LoadItem());
    }

    private void OnDisable()
    {
        Close();
    }

    public void Open()
    {
        _view.NextItemSetted += OnNextItemSetted;
        _view.PreviousItemSetted += OnPreviousItemSetted;
        _view.ItemSelected += OnItemSelected;

        _selectItem = LoadItem();

        _currentItem = _selectItem;

        SetItem(_currentItem);
        SetSelectItem(_selectItem);
    }

    public void Close()
    {
        _view.NextItemSetted -= OnNextItemSetted;
        _view.PreviousItemSetted -= OnPreviousItemSetted;
        _view.ItemSelected -= OnItemSelected;

        _view.TryDeactivateItem();

        Save(SaveKey);
    }

    private void OnNextItemSetted()
    {
        var currentItemIndex = Items.IndexOf(_currentItem);

        _currentItem = currentItemIndex + 1 < Items.Count ? Items[currentItemIndex + 1] : Items.First();

        SetItem(_currentItem);
    }

    private void OnPreviousItemSetted()
    {
        var currentItemIndex = Items.IndexOf(_currentItem);

        _currentItem = currentItemIndex - 1 >= 0 ? Items[currentItemIndex - 1] : Items.Last();

        SetItem(_currentItem);
    }

    private void OnItemSelected()
    {
        if (_currentItem.TrySecelct(_view.Player))
        {
            _selectItem = _currentItem;
            _view.SetButton(_currentItem == _selectItem);
            _view.SetPrice(_currentItem);

            Save(SaveKey);
            SetSelectItem(_selectItem);
        }
    }

    private void SetItem(Item item)
    {
        _view.SetItem(item);
        _view.SetButton(_currentItem == _selectItem);
        _view.SetPrice(item);
    }

    private Item LoadItem()
    {
        Item item = null;

        if (Items != null)
            item = LoadStaticItem();

        if (item == null)
            item = Load(SaveKey);

        if (item == null)
        {
            foreach (var element in Items)
            {
                if (element.IsBuyed)
                    return element;
            }
        }

        if (item == null)
            item = _defaultItem;

        return item;
    }

    private void Save(string key) => SaveManager.Save(key, CreateSavesnapshot());

    private Item Load(string key)
    {
        StoreProfile data = SaveManager.Load<StoreProfile>(key);

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

    protected abstract Item LoadStaticItem();

    protected abstract void SetSelectItem(Item item);
}
