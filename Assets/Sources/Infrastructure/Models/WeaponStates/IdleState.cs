namespace BattleIsland.Infrustructure.Model
{
    public class IdleState : State
    {
        public override bool CanShoot() =>
            true;
    }
}
