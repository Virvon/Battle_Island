using Assets.Sources.GameLogic.Learning.Triggers;
using Assets.Sources.Infrastructure.Views.Menu;
using UnityEngine;

namespace Assets.Sources.GameLogic.Learning
{
    public class LoadNextSceneTrigger : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour _triggerBehavior;
        [SerializeField] private MenuView _menuView;

        private ITriggerable _trigger;

        private void Awake()
        {
            _trigger = (ITriggerable)_triggerBehavior;
            _trigger.Triggered += _menuView.LoadNextScene;
        }

        private void OnDisable() =>
            _trigger.Triggered -= _menuView.LoadNextScene;

        private void OnValidate()
        {
            if (_triggerBehavior && _triggerBehavior is not ITriggerable)
            {
                Debug.LogError(nameof(_triggerBehavior) + " needs to implement " + nameof(ITriggerable));
                _triggerBehavior = null;
            }
        }
    }
}