using Assets.Sources.Infrastructure.Views;
using UnityEngine;

namespace Assets.Sources.GameLogic.Priority
{
    public class PriorityElement
    {
        private const int DefaultDistance = 150;
        private const float MurderModifire = 1.3f;
        private const float PriorityModifire = 1.5f;
        private const float PriorityRangeModifire = 1.5f;

        public PriorityElement(MovementObject target) =>
            Target = target;

        public MovementObject Target { get; private set; }

        public float PriorityValue { get; private set; }

        public float CalculatePriorityValue(MovementObject parent)
        {
            float priorityValue = DefaultDistance /
                (Target.transform.position - parent.transform.position).magnitude;
            priorityValue += Target.MurdersCount * MurderModifire;

            if (Target is PlayerView)
                priorityValue *= PriorityModifire;

            priorityValue += Random.Range(
                -(priorityValue / PriorityRangeModifire),
                priorityValue / PriorityRangeModifire);

            PriorityValue = priorityValue;

            return priorityValue;
        }
    }
}