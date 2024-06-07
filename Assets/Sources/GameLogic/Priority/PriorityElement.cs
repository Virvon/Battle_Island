using BattleIsland.Infrastructure.View;
using UnityEngine;

namespace BattleIsland.GameLogic
{
    public class PriorityElement
    {
        public MovementObject Target { get; private set; }

        public float PriorityValue { get; private set; }

        public PriorityElement(MovementObject target)
        {
            Target = target;
        }

        public float CalculatePriorityValue(MovementObject parent)
        {
            var priorityValue = 150 / (Target.transform.position - parent.transform.position).magnitude;
            priorityValue += Target.MurdersCount * 1.3f;

            if (Target is PlayerView)
                priorityValue *= 1.5f;

            priorityValue += Random.Range(-(priorityValue / 1.5f), (priorityValue / 1.5f));

            PriorityValue = priorityValue;

            return priorityValue;
        }
    }
}