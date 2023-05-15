using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    [SerializeField] private string[] _nextScenes;
    [SerializeField] private GameObject _loadPanel;

    private SceneLoader _gameSceneLoader;

    public void LoadNextScene()
    {
        _loadPanel.SetActive(true);
        _gameSceneLoader = new SceneLoader(_nextScenes[Random.Range(0, _nextScenes.Length)]);
        _gameSceneLoader.Load();
    }
}
