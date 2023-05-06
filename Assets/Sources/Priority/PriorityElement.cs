using UnityEngine;

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
        var priorityValue = 120 / (Target.transform.position - parent.transform.position).magnitude;
        priorityValue += Target.MurdersCount * 1.4f;

        if (Target is PlayerView)
            priorityValue *= 1.4f;

        priorityValue += Random.Range(-(priorityValue / 2), (priorityValue / 2));

        PriorityValue = priorityValue;

        return priorityValue;
    }
}
