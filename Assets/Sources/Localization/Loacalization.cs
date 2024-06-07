using UnityEngine;
using Lean.Localization;
using BattleIsland.SaveData;

public class Loacalization : MonoBehaviour
{
    [SerializeField] private string _defaultLanguage;
    [SerializeField] private string _saveKey;

    private void Awake()
    {
        string language;

        language = Load();

        if (language == null)
            language = _defaultLanguage;

        LeanLocalization.SetCurrentLanguageAll(language);
    }

    public void ChangeLanguage(string language)
    {
        LeanLocalization.SetCurrentLanguageAll(language);
        Save(language);
    }

    private void Save(string currentLanguage)
    {
        SaveLoadService.Save(_saveKey, GetSaveProfile(currentLanguage));
    }

    private string Load()
    {
        return SaveLoadService.Load<LocalizationProfile>(_saveKey).CurrentLenguage;
    }

    private LocalizationProfile GetSaveProfile(string currentLanguage)
    {
        var data = new LocalizationProfile()
        {
            CurrentLenguage = currentLanguage
        };

        return data;
    }
}
