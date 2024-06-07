using BattleIsland.GameLogic;
using BattleIsland.Infrastructure.Presenter;
using BattleIsland.Infrustructure.Model;
using BattleIsland.UI;
using UnityEngine;

namespace BattleIsland.Infrastructure.View
{
    public class GameMenuView : MenuView
    {
        [SerializeField] private GameObject _resultPanel;
        [SerializeField] private GameTimer _timer;
        [SerializeField] private UnitsSpawner _enemySpawner;
        [SerializeField] private LeaderBoard _leaderboard;

        private const SceneId NextScene = SceneId.Menu;

        private void OnEnable() =>
            _timer.TimeOvered += OpenResultPanel;

        private void OnDisable() =>
            _timer.TimeOvered -= OpenResultPanel;

        private void OpenResultPanel() =>
            ((GameMenuPresenter)Presenter).OpenResultPanel();

        public override SceneId GetScene() =>
            NextScene;
    }
}