using System;

namespace Assets.Sources.GameLogic.Learning.Triggers
{
    public interface ITriggerable
    {
        public event Action Triggered;
    }
}