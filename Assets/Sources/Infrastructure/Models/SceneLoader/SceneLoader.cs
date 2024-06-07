using UnityEngine.SceneManagement;

namespace BattleIsland.Infrustructure.Model
{
    public class SceneLoader
    {
        public void Load(SceneId scene) =>
            SceneManager.LoadScene((int)scene);
    }
}
