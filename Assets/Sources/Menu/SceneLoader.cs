using UnityEngine.SceneManagement;

public class SceneLoader
{
    private string _sceneName;

    public SceneLoader(string sceneName)
    {
        _sceneName = sceneName;
    }

    public void Load()
    {
        SceneManager.LoadScene(_sceneName);
    }
}