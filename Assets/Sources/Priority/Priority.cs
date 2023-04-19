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
        return elements.First().Target;

        if(elements.Length >= 3)
        {
            Debug.Log(Mathf.Abs((elements[0].PriorityValue - elements[1].PriorityValue)));

            if ((elements[0].Target.transform.position - elements[1].Target.transform.position).magnitude < 6 && (elements[0].Target.transform.position - parent.transform.position).magnitude < 12)
                return elements[2].Target;
        }

    }
}
