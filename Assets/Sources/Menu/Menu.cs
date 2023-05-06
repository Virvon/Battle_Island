using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    [SerializeField] private string _nextScene;
    [SerializeField] private GameObject _loadPanel;

    private SceneLoader _gameSceneLoader;

    public void LoadNextScene()
    {
        _loadPanel.SetActive(true);
        _gameSceneLoader = new SceneLoader(_nextScene);
        _gameSceneLoader.Load();
    }
}
