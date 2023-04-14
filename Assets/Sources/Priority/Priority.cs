using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Priority
{
    private List<PriorityElement> priorities;

    public Priority(List<MovementObject> targets)
    {
        priorities = new List<PriorityElement>();

        foreach(var target in targets)
            priorities.Add(new PriorityElement(target));
    }

    public MovementObject Choose(MovementObject parent)
    {
        var elements = priorities.OrderByDescending(element => element.CalculatePriorityValue(parent)).ToArray();

        if(elements.Length >= 2)
        {
            if (Mathf.Abs((elements[0].PriorityValue - elements[1].PriorityValue)) < 0)
                return null;
        }

        return elements.First().Target;
    }
}
