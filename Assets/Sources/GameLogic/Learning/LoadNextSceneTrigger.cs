using UnityEngine;

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

    public void OnDisable() =>
        _trigger.Triggered -= _menuView.LoadNextScene;

    private void OnValidate()
    {
        if (_triggerBehavior && !(_triggerBehavior is ITriggerable))
        {
            Debug.LogError(nameof(_triggerBehavior) + " needs to implement " + nameof(ITriggerable));
            _triggerBehavior = null;
        }
    }
}