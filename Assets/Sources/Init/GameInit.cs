using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class GameInit : MonoBehaviour
{
    [SerializeField] private SceneNames _startScene;

    private SceneLoader _sceneLoader;

    public static Platform Platform;

    private void Awake()
    {
        _sceneLoader = new SceneLoader(_startScene);
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        SetPlatform();
        _sceneLoader.Load();
        yield break;
#else
        yield return YandexGamesSdk.Initialize();

        if (YandexGamesSdk.IsInitialized == false)
            throw new ArgumentNullException(nameof(YandexGamesSdk), "Yandex SDK didn't initialized correctly");

        YandexGamesSdk.CallbackLogging = true;

        SetPlatform();
        _sceneLoader.Load();
#endif
    }

    private void SetPlatform()
    {
        Platform = Application.isMobilePlatform ? Platform.Mobile : Platform.Desktop;
    }
}
