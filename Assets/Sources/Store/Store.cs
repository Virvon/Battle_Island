using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Store : MonoBehaviour
{
    [SerializeField] private StoreView _view;
    [SerializeField] private string SaveKey;

    private Item _currentItem;

    protected List<Item> Items;
    protected Item SelectItem;

    private void Start()
    {
        Items = GetComponentsInChildren<Item>().ToList();

        Open();
    }

    private void OnDisable() => Close();

    public void Open()
    {
        _view.NextItemSetted += OnNextItemSetted;
        _view.PreviousItemSetted += OnPreviousItemSetted;
        _view.ItemSelected += OnItemSelected;

        if(Items != null)
            LoadStaticItem();

        if (SelectItem == null)
            SelectItem = Load(SaveKey);

        if (SelectItem == null)
            SelectItem = Items.Where(item => item.IsBuyed).First();

        _currentItem = SelectItem;

        Debug.Log("item: " + SelectItem);

        SetItem(_currentItem);
    }

    public void Close()
    {
        _view.TryDeactivateItem();

        _view.NextItemSetted -= OnNextItemSetted;
        _view.PreviousItemSetted -= OnPreviousItemSetted;
        _view.ItemSelected -= OnItemSelected;

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
            SelectItem = _currentItem;
            _view.SetButton(_currentItem == SelectItem);
            _view.SetPrice(_currentItem);

            Save(SaveKey);
        }
    }

    private void SetItem(Item item)
    {
        _view.SetItem(item);
        _view.SetButton(_currentItem == SelectItem);
        _view.SetPrice(item);
    }

    private void Save(string key) => SaveManger.Save(key, CreateSavesnapshot());

    private Item Load(string key)
    {
        StoreProfile data = SaveManger.Load<StoreProfile>(key);

        return data.SelectItem;
    }

    private StoreProfile CreateSavesnapshot()
    {
        StoreProfile data = new()
        {
            SelectItem = SelectItem
        };

        return data;
    }

    protected abstract void LoadStaticItem();
}
