using BattleFieldSolution.Domain.Model.Unit.Behaviour.State;
using BattleFieldSolution.Service.TimeService;

namespace BattleFieldSolution.Domain.Model.Unit.Behaviour;

public class UnitBehaviour
{
    private readonly ITimeListener _timeListener;

    private IUnitBehaviourState _state;

    public UnitBehaviour(ITimeListener timeListener)
    {
        _timeListener = timeListener;
        timeListener.Ticked += OnTimeTicked;
        SetState(new AwakeBehaviourState());
    }
    
    public event Action<IUnitBehaviourState>? StateChanged;

    public bool IsDestroyed => _state is DestroyBehaviorState; 

    public void Enable() => 
        _state.Enable(this);

    public void Disable() => 
        _state.Disable(this);

    public virtual void Update(ulong time) { }

    public void Destroy()
    {
        _timeListener.Ticked -= OnTimeTicked;
        _state.Destroy(this);
    }

    public void SetState(IUnitBehaviourState state)
    {
        _state = state;
        StateChanged?.Invoke(state);
    }
    
    private void OnTimeTicked(ulong time) =>
        _state.OnTick(this, time);
}