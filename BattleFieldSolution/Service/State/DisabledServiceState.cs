using BattleFieldSolution.Service.TimeService;

namespace BattleFieldSolution.Service.State;

public class DisabledServiceState : IServiceState
{
    public void Enable(Service service) => 
        service.SetState(new EnabledServiceState());

    public void Disable(Service service) { }

    public void Destroy(Service service) => 
        service.SetState(new DestroyServiceState());
    
    public void Accept(IServiceStateVisitor visitor) => 
        visitor.Visit(this);
}