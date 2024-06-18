using Assets.Sources.GameLogic.Spawners;
using Assets.Sources.Infrastructure.Models;
using Assets.Sources.Infrastructure.Presenters;
using Assets.Sources.UI;
using UnityEngine;

namespace Assets.Sources.Infrastructure.Views.Menu
{
    public class GameMenuView : MenuView
    {
        private const SceneId NextScene = SceneId.Menu;

        [SerializeField] private GameObject _resultPanel;
        [SerializeField] private GameTimer _timer;
        [SerializeField] private UnitsSpawner _enemySpawner;
        [SerializeField] private LeaderBoard _leaderboard;

        private void OnEnable() =>
            _timer.TimeOvered += OpenResultPanel;

        private void OnDisable() =>
            _timer.TimeOvered -= OpenResultPanel;

        public override SceneId GetScene() =>
            NextScene;

        private void OpenResultPanel() =>
            ((GameMenuPresenter)Presenter).OpenResultPanel();
    }
}