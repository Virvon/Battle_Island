using BattleIsland.GameLogic.Spawner;
using BattleIsland.Infrastructure.Presenter;
using BattleIsland.Infrustructure.Model;
using BattleIsland.UI;
using UnityEngine;

namespace BattleIsland.Infrastructure.View.Menu
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