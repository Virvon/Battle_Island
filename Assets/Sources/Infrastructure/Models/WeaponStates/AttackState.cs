namespace BattleIsland.Infrustructure.Model
{
    public class AttackState : State
    {
        public override bool CanComeback() => 
            true;
    }
}
