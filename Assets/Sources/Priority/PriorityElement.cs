using System.Collections;
using System.Collections.Generic;
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
        var priorityValue = 100 / (Target.transform.position - parent.transform.position).magnitude;
        priorityValue += Random.Range(-(priorityValue / 2), (priorityValue / 2));

        PriorityValue = priorityValue;

        return priorityValue;
    }
}
