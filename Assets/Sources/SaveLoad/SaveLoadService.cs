using UnityEngine;

namespace BattleIsland.SaveLoad
{
    public static class SaveLoadService
    {
        public static void Save<T>(string key, T saveData)
        {
            string jsonData = JsonUtility.ToJson(saveData, true);
            PlayerPrefs.SetString(key, jsonData);
        }

        public static T Load<T>(string key) where T : new() =>
            PlayerPrefs.HasKey(key) ? JsonUtility.FromJson<T>(PlayerPrefs.GetString(key)) : new T();
    }
}