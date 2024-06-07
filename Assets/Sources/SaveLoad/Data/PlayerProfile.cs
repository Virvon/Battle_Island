using System;

namespace BattleIsland.SaveLoad.Data
{
    [Serializable] 
    public class PlayerProfile
    {
        public int Money;

        public PlayerProfile()
        {
            Money = 25000;
        }
    }
}
