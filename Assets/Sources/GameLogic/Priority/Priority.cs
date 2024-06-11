using System.Collections.Generic;
using System.Linq;
using BattleIsland.Infrastructure.View;

namespace BattleIsland.GameLogic.Priority
{
    public class Priority
    {
        private List<PriorityElement> priorities;

        private MovementObject _parent;

        public Priority(List<MovementObject> targets, MovementObject parent)
        {
            priorities = new List<PriorityElement>();

            _parent = parent;

            foreach (var target in targets)
                priorities.Add(new PriorityElement(target));
        }

        public MovementObject Choose()
        {
            PriorityElement[] elements = priorities.OrderByDescending(
                element => element.CalculatePriorityValue(_parent))
                .ToArray();

            return elements.First().Target;
        }

        public MovementObject ChooseLessPriority()
        {
            PriorityElement[] elements = priorities.OrderByDescending(
                element => element.CalculatePriorityValue(_parent))
                .ToArray();

            return elements.Last().Target;
        }
    }
}