using System;
using System.Collections;
using Agava.YandexGames;
using BattleIsland.Infrustructure.Model;
using UnityEngine;

namespace BattleIsland.Infrastructure.Bootstrap
{
    public class GameInit : MonoBehaviour
    {
        [SerializeField] private SceneId _startScene;

        public static Platform Platform;

        private SceneLoader _sceneLoader;

        private void Awake() =>
            _sceneLoader = new SceneLoader();

        private IEnumerator Start()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            SetPlatform();
            _sceneLoader.Load(_startScene);
            yield break;
#else
        yield return YandexGamesSdk.Initialize();

        if (YandexGamesSdk.IsInitialized == false)
            throw new ArgumentNullException(nameof(YandexGamesSdk), "Yandex SDK didn't initialized correctly");

        YandexGamesSdk.CallbackLogging = true;

        SetPlatform();
        _sceneLoader.Load(_startScene);
#endif
        }

        private void SetPlatform() =>
            Platform = Application.isMobilePlatform ? Platform.Mobile : Platform.Desktop;
    }
}