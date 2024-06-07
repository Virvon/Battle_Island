namespace BattleIsland.Model
{
    public abstract class State
    {
        public virtual bool CanShoot() => 
            false;

        public virtual bool CanComeback() => 
            false;
    }
}
