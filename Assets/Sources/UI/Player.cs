using System;
using Assets.Sources.SaveLoad;
using Assets.Sources.SaveLoad.Data;
using UnityEngine;

namespace Assets.Sources.UI
{
    public class Player : MonoBehaviour
    {
        private const string SaveKey = "PlayerSaveKey";

        public event Action MoneyCountChanged;

        public int Money { get; private set; }

        private void Start()
        {
            Money = LoadMoney(SaveKey) + ScoreCounter.Money;
            SaveMoney(SaveKey);

            MoneyCountChanged?.Invoke();
        }

        public bool TryGetMoney(int count)
        {
            if (count > Money)
                return false;

            Money -= count;
            SaveMoney(SaveKey);
            MoneyCountChanged?.Invoke();

            return true;
        }

        private void SaveMoney(string key) =>
            SaveLoadService.Save(key, CreateSaveSnapshot());

        private int LoadMoney(string key)
        {
            PlayerProfile data = SaveLoadService.Load<PlayerProfile>(key);

            return data.Money;
        }

        private PlayerProfile CreateSaveSnapshot()
        {
            PlayerProfile data = new PlayerProfile()
            {
                Money = Money,
            };

            return data;
        }
    }
}