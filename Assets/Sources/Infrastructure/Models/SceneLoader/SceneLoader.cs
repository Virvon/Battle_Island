using UnityEngine.SceneManagement;

public class SceneLoader
{
    public void Load(SceneId scene) => 
        SceneManager.LoadScene((int)scene);
}
