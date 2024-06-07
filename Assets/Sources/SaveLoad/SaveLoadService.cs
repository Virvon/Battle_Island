using UnityEngine;

namespace BattleIsland.SaveLoad
{
    static class SaveLoadService
    {
        public static void Save<T>(string key, T saveData)
        {
            string jsonData = JsonUtility.ToJson(saveData, true);
            PlayerPrefs.SetString(key, jsonData);
        }

        public static T Load<T>(string key) where T : new()
        {
            if (PlayerPrefs.HasKey(key))
            {
                var loadedString = PlayerPrefs.GetString(key);
                return JsonUtility.FromJson<T>(loadedString);
            }
            else
            {
                return new T();
            }
        }
    }
}