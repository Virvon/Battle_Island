using UnityEngine.SceneManagement;

namespace Assets.Sources.Infrastructure.Models
{
    public class SceneLoader
    {
        public void Load(SceneId scene) =>
            SceneManager.LoadScene((int)scene);
    }
}
