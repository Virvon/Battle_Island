using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleIsland.GameLogic.Learning
{
    public interface ITriggerable
    {
        public event Action Triggered;
    }
}