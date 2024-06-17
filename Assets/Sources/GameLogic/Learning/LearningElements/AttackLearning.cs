using UnityEngine;

namespace BattleIsland.GameLogic.Learning.LearningElements
{
    public class AttackLearning : Learning
    {
        [SerializeField] private Door _door;

        protected override void OnEndTriggered()
        {
            _door.Open();
            base.OnEndTriggered();
        }
    }
}