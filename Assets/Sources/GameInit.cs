using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using Lean.Localization;

public class GameInit : MonoBehaviour
{
    [SerializeField] private string _startScene;
    [SerializeField] private List<LeanLanguage> _languages;

    private SceneLoader _sceneLoader;

    public static Platform Platform;

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;

        _sceneLoader = new SceneLoader(_startScene);
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();

        if (YandexGamesSdk.IsInitialized == false)
            throw new ArgumentNullException(nameof(YandexGamesSdk), "Yandex SDK didn't initialized correctly");

        SetLanguage();
        SetPlatform();
        _sceneLoader.Load();
    }

    private void SetLanguage()
    {
        var language = Application.systemLanguage;

        LeanLocalization.SetCurrentLanguageAll(language.ToString());
    }

    private void SetPlatform()
    {
        Platform = Application.isMobilePlatform ? Platform.Mobile : Platform.Desktop;
    }
}
