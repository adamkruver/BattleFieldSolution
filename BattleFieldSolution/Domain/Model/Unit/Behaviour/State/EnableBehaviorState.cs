namespace BattleFieldSolution.Domain.Model.Unit.Behaviour.State;

public class EnableBehaviorState : IUnitBehaviourState
{
    public void Enable(UnitBehaviour behaviour) { }

    public void Disable(UnitBehaviour behaviour) => 
        behaviour.SetState(new DisableBehaviorState());

    public void Destroy(UnitBehaviour behaviour) => 
        behaviour.SetState(new DestroyBehaviorState());

    public void OnTick(UnitBehaviour behaviour, ulong time) => 
        behaviour.Update(time);
}