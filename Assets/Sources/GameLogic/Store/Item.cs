using System;
using UnityEngine;
using Assets.Sources.SaveLoad.Data;
using Assets.Sources.SaveLoad;
using Assets.Sources.UI;

namespace Assets.Sources.GameLogic.Store
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] private int _price;
        [SerializeField] private string _saveKey;

        public event Action Selled;

        public int Price => _price;
        public bool IsBuyed { get; private set; }

        private void Awake()
        {
            Load(_saveKey);

            if (_price == 0)
                IsBuyed = true;
        }

        public abstract void Activate(Vector3 position);

        public abstract void Deactivate();

        public bool TrySecelct(Player player)
        {
            if (IsBuyed == false)
                TryBuy(player);

            return IsBuyed;
        }

        private void TryBuy(Player player)
        {
            if (player.TryGetMoney(Price))
            {
                IsBuyed = true;
                Selled?.Invoke();
                Save(_saveKey);
            }
        }

        private void Save(string key) =>
            SaveLoadService.Save(key, CreateSaveSnapshot());

        private void Load(string key)
        {
            ItemPofile profile = SaveLoadService.Load<ItemPofile>(key);

            IsBuyed = profile.IsBuyed;
        }

        private ItemPofile CreateSaveSnapshot()
        {
            ItemPofile data = new ItemPofile();

            data.IsBuyed = IsBuyed;

            return data;
        }
    }
}