using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Priority
{
    private List<PriorityElement> priorities;

    private MovementObject _parent;

    public Priority(List<MovementObject> targets, MovementObject parent)
    {
        priorities = new List<PriorityElement>();

        _parent = parent;

        foreach(var target in targets)
            priorities.Add(new PriorityElement(target));
    }

    public MovementObject Choose()
    {
        var elements = priorities.OrderByDescending(element => element.CalculatePriorityValue(_parent)).ToArray();

        return elements.First().Target;

        if(elements.Length >= 3)
        {
            Debug.Log(Mathf.Abs((elements[0].PriorityValue - elements[1].PriorityValue)));

            if ((elements[0].Target.transform.position - elements[1].Target.transform.position).magnitude < 6 && (elements[0].Target.transform.position - _parent.transform.position).magnitude < 12)
                return elements[2].Target;
        }

    }

    public MovementObject ChooseLessPriority()
    {
        var elements = priorities.OrderByDescending(element => element.CalculatePriorityValue(_parent)).ToArray();

        return elements.Last().Target;
    }
}
