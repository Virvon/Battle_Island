using BattleIsland.SaveData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnMenu : Menu
{
    [SerializeField] private SceneNames _nextScene;
    [SerializeField] private MonoBehaviour _triggerBehavior;
    [SerializeField] private float _delay;
    [SerializeField] private string _saveKey;

    private ITriggerable _trigger;

    private void Awake()
    {
        _trigger = (ITriggerable)_triggerBehavior;
        _trigger.Triggered += LoadNextScene;
    }

    public void OnDisable() => _trigger.Triggered -= LoadNextScene;

    private void OnValidate()
    {
        if(_triggerBehavior && !(_triggerBehavior is ITriggerable))
        {
            Debug.LogError(nameof(_triggerBehavior) + " needs to implement " + nameof(ITriggerable));
            _triggerBehavior = null;
        }
    }

    public override void LoadNextScene() => StartCoroutine(Waiter(_delay));

    public override SceneNames GetScene()
    {
        return _nextScene;
    }

    private IEnumerator Waiter(float dalay)
    {
        Save();

        yield return new WaitForSeconds(dalay);

        base.LoadNextScene();
    }

    private void Save()
    {
        SaveLoadService.Save(_saveKey, CreateSaveSnapshot());
    }

    private LearningProfile CreateSaveSnapshot()
    {
        LearningProfile data = new LearningProfile()
        {
            IsFinish = true
        };

        return data;
    }
}
