using System.Collections;
using UnityEngine;

namespace BattleIsland.GameLogic.Learning
{
    public class Learning : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour _startTriggerBehavior;
        [SerializeField] private MonoBehaviour _endTriggerBehavior;

        [SerializeField] private float _startDelay;
        [SerializeField] private float _endDelay;

        [SerializeField] private LearnPanel _learnPanel;

        private ITriggerable _endTrigger;
        private ITriggerable _startTrigger;
        private WaitForSeconds _startWaitForSeconds;
        private WaitForSeconds _endWaitForSeconds;

        private void Awake()
        {
            _startTrigger = (ITriggerable)_startTriggerBehavior;
            _endTrigger = (ITriggerable)_endTriggerBehavior;

            _startWaitForSeconds = new(_startDelay);
            _endWaitForSeconds = new(_endDelay);
        }

        private void OnValidate()
        {
            if (_startTriggerBehavior && !(_startTriggerBehavior is ITriggerable))
            {
                Debug.LogError(nameof(_startTriggerBehavior) + " needs to implement " + nameof(ITriggerable));
                _startTriggerBehavior = null;
            }

            if (_endTriggerBehavior && !(_endTriggerBehavior is ITriggerable))
            {
                Debug.LogError(nameof(_endTriggerBehavior) + " needs to implement " + nameof(ITriggerable));
                _endTriggerBehavior = null;
            }
        }

        private void OnEnable()
        {
            _startTrigger.Triggered += StartDelay;
            _endTrigger.Triggered += EndDelay;
        }

        private void OnDisable()
        {
            _startTrigger.Triggered -= StartDelay;
            _endTrigger.Triggered -= EndDelay;
        }

        protected virtual void OnStartTriggered() => 
            _learnPanel.Open();

        protected virtual void OnEndTriggered() => 
            _learnPanel.Close();

        private void StartDelay() =>
            StartCoroutine(StartWaiter());

        private void EndDelay() => 
            StartCoroutine(EndWaiter());

        private IEnumerator StartWaiter()
        {
            yield return _startWaitForSeconds;

            OnStartTriggered();
        }

        private IEnumerator EndWaiter()
        {
            yield return _endWaitForSeconds;

            OnEndTriggered();
            gameObject.SetActive(false);
        }
    }
}