using System.Collections;
using Assets.Sources.SaveLoad;
using Assets.Sources.SaveLoad.Data;
using BattleIsland.Infrustructure.Model;
using UnityEngine;

namespace Assets.Sources.Infrastructure.Views.Menu
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