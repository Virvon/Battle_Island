using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleIsland.SaveData;

namespace BattleIsland.Menu
{
    public class Player : MonoBehaviour
    {
        private int _momey;
        private const string SaveKey = "SaveKey";

        private void OnEnable()
        {
            _momey = LoadMoney(SaveKey) + ScoreCounter.Money;
            Save(SaveKey);

            Debug.Log("Money: " + _momey);
        }

        private void Save(string key)
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
