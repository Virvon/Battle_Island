using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleIsland.Model
{
    public class Enemy
    {
        public event Action Moved;
        public event Action Died;

        public void SetTarget()
        {
            Moved?.Invoke();
        }

        public void TakeDamage()
        {
            Died?.Invoke();
        }
    }
}
