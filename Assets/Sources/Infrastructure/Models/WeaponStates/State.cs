namespace BattleIsland.Infrustructure.Model
{
    public abstract class State
    {
        public virtual bool CanShoot() =>
            false;

        public virtual bool CanComeback() =>
            false;
    }
}