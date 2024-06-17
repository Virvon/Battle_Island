using BattleIsland.Infrustructure.Model;

namespace Assets.Sources.Infrastructure.Presenters
{
    public class MenuPresenter
    {
        private readonly Menu _menu;

        public MenuPresenter(Menu menu) =>
            _menu = menu;

        public void LoadScene(SceneId sceneName) =>
            _menu.LoadScene(sceneName);
    }
}