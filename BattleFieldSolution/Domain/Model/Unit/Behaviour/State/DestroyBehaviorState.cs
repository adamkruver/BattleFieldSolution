namespace BattleFieldSolution.Domain.Model.Unit.Behaviour.State;

public class DestroyBehaviorState : IUnitBehaviourState
{
    public void Enable(UnitBehaviour behaviour) { }
    public void Disable(UnitBehaviour behaviour) { }
    public void Destroy(UnitBehaviour behaviour) { }
    public void OnTick(UnitBehaviour behaviour, ulong time) { }
}