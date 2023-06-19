using UnityEngine.SceneManagement;

public class SceneLoader
{
    private SceneNames _scene;

    public SceneLoader(SceneNames sceneName)
    {
        _scene = sceneName;
    }

    public void Load()
    {
        SceneManager.LoadScene((int)_scene);
    }
}
