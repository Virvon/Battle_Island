using BattleIsland.SaveLoad;
using BattleIsland.SaveLoad.Data;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BattleIsland.GameLogic.Store
{
    public abstract class Store : MonoBehaviour
    {
        [SerializeField] private StoreWindow _view;
        [SerializeField] private Item _defaultItem;
        [SerializeField] private string SaveKey;

        private List<Item> _items;
        private Item _currentItem;

        protected Item _selectItem { get; private set; }
        protected IReadOnlyList<Item> Items => _items;

        private void OnEnable()
        {
            _items = GetComponentsInChildren<Item>().ToList();

            SetSelectItem(LoadItem());
        }

        private void OnDisable() =>
            Close();

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
            var currentItemIndex = _items.IndexOf(_currentItem);

            _currentItem = currentItemIndex + 1 < _items.Count ? _items[currentItemIndex + 1] : _items.First();

            SetItem(_currentItem);
        }

        private void OnPreviousItemSetted()
        {
            var currentItemIndex = _items.IndexOf(_currentItem);

            _currentItem = currentItemIndex - 1 >= 0 ? _items[currentItemIndex - 1] : _items.Last();

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

            if (_items != null)
                item = LoadStaticItem();

            if (item == null)
                item = Load(SaveKey);

            if (item == null)
            {
                foreach (var element in _items)
                {
                    if (element.IsBuyed)
                        return element;
                }
            }

            if (item == null)
                item = _defaultItem;

            return item;
        }

        private void Save(string key) =>
            SaveLoadService.Save(key, CreateSavesnapshot());

        private Item Load(string key)
        {
            StoreProfile data = SaveLoadService.Load<StoreProfile>(key);

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
}