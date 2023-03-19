namespace BattleFieldSolution.Domain.Model.Unit.Behaviour.State;

public interface IUnitBehaviourState
{
        void Enable(UnitBehaviour behaviour);
        void Disable(UnitBehaviour behaviour);
        void Destroy(UnitBehaviour behaviour);
        void OnTick(UnitBehaviour behaviour, ulong time);
}