using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleIsland.SaveData;

namespace BattleIsland.Menu
{
    public class Player : MonoBehaviour
    {
        private int _momey;
        private const string SaveKey = "PlayerSaveKey";

        private void OnEnable()
        {
            _momey = LoadMoney(SaveKey) + ScoreCounter.Money;
            SaveMoney(SaveKey);

            Debug.Log("Money: " + _momey);
        }

        public bool TryGetMoney(int count)
        {
            if(count > _momey)
                return false;

            _momey -= count;
            SaveMoney(SaveKey);

            return true;
        }

        private void SaveMoney(string key)
        {
            SaveManger.Save(key, CreateSaveSnapshot());
        }

        private int LoadMoney(string key)
        {
            PlayerProfile data = SaveManger.Load<PlayerProfile>(key);

            return data.Money;
        }

        private PlayerProfile CreateSaveSnapshot()
        {
            PlayerProfile data = new PlayerProfile()
            {
                Money = _momey
            };

            return data;
        }
    }
}
