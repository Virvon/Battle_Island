using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleIsland.Model
{
    public class AttackState : State
    {
        public override bool CanComeback()
        {
            return true;
        }
    }
}
