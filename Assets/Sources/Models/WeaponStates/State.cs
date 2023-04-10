using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleIsland.Model
{
    public abstract class State
    {
        public virtual bool CanShoot() 
        { 
            return false;
        }

        public virtual bool CanComeback()
        {
            return false;
        }
    }
}
