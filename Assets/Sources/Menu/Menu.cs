using UnityEngine;

public abstract class Menu : MonoBehaviour
{ 
    [SerializeField] private GameObject _loadPanel;

    private SceneLoader _gameSceneLoader;

    public virtual void LoadNextScene()
    {
        _loadPanel.SetActive(true);
        _gameSceneLoader = new SceneLoader(GetScene());
        _gameSceneLoader.Load();
    }

    public abstract string GetScene();
}
