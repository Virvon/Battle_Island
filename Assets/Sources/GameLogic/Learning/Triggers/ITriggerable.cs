using System;

namespace BattleIsland.GameLogic.Learning.Triggers
{
    public interface ITriggerable
    {
        public event Action Triggered;
    }
}