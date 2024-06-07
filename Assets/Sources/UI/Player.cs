using UnityEngine;
using System;
using BattleIsland.SaveLoad;
using BattleIsland.SaveLoad.Data;

namespace BattleIsland.UI
{
    public class Player : MonoBehaviour
    {
        public int Money { get; private set; }

        private const string SaveKey = "PlayerSaveKey";

        public event Action MoneyCountChanged;

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

        private void SaveMoney(string key)
        {
            SaveLoadService.Save(key, CreateSaveSnapshot());
        }

        private int LoadMoney(string key)
        {
            PlayerProfile data = SaveLoadService.Load<PlayerProfile>(key);

            return data.Money;
        }

        private PlayerProfile CreateSaveSnapshot()
        {
            PlayerProfile data = new PlayerProfile()
            {
                Money = Money
            };

            return data;
        }
    }
}