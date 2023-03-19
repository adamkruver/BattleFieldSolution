namespace BattleFieldSolution.Domain.Model.Unit.Behaviour.State;

public class DisableBehaviorState: IUnitBehaviourState
{
    public void Enable(UnitBehaviour behaviour) => 
        behaviour.SetState(new EnableBehaviorState());

    public void Disable(UnitBehaviour behaviour) { }

    public void Destroy(UnitBehaviour behaviour) => 
        behaviour.SetState(new DestroyBehaviorState());

    public void OnTick(UnitBehaviour behaviour, ulong time) { }
}