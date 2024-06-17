using Assets.Sources.Infrastructure.Presenters;
using BattleIsland.Infrustructure.Model;
using UnityEngine;

namespace Assets.Sources.Infrastructure.Views.Menu
{
    public abstract class MenuView : MonoBehaviour
    {
        [SerializeField] private GameObject _loadPanel;

        protected MenuPresenter Presenter { get; private set; }

        public void Init(MenuPresenter presenter) =>
            Presenter = presenter;

        public virtual void LoadNextScene()
        {
            _loadPanel.SetActive(true);
            Presenter.LoadScene(GetScene());
        }

        public abstract SceneId GetScene();
    }
}