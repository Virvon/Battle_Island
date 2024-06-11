using System.Collections;
using BattleIsland.Infrustructure.Model;
using BattleIsland.SaveLoad;
using BattleIsland.SaveLoad.Data;
using UnityEngine;

namespace BattleIsland.Infrastructure.View
{
    public class LearnMenu : MenuView
    {
        [SerializeField] private SceneId _nextScene;
        [SerializeField] private float _delay;
        [SerializeField] private string _saveKey;

        public override void LoadNextScene() =>
            StartCoroutine(Waiter(_delay));

        public override SceneId GetScene() =>
            _nextScene;

        private IEnumerator Waiter(float dalay)
        {
            Save();

            yield return new WaitForSeconds(dalay);

            base.LoadNextScene();
        }

        private void Save() =>
            SaveLoadService.Save(_saveKey, CreateSaveSnapshot());

        private LearningProfile CreateSaveSnapshot()
        {
            LearningProfile data = new LearningProfile()
            {
                IsFinish = true,
            };

            return data;
        }
    }
}