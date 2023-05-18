using System.Collections;
using UnityEngine;
using Agava.YandexGames;
using System;

public class GameInit : MonoBehaviour
{
    [SerializeField] private string _startScene;

    private SceneLoader _sceneLoader;

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


        _sceneLoader.Load();
    }
}
