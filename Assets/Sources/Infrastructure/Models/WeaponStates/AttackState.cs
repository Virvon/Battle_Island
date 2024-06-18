namespace Assets.Sources.Infrastructure.Models
{
    public class AttackState : State
    {
        public override bool CanComeback() => 
            true;
    }
}
