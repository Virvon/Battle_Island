using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private string _nextScene;

    private SceneLoader _gameSceneLoader;

    public void LoadNextScene()
    {
        _gameSceneLoader = new SceneLoader(_nextScene);
        _gameSceneLoader.Load();
    }
}
