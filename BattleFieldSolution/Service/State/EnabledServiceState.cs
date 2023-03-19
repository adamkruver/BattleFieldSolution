using BattleFieldSolution.Service.TimeService;

namespace BattleFieldSolution.Service.State;

public class EnabledServiceState : IServiceState
{
    public void Enable(Service service) { }

    public void Disable(Service service) => 
        service.SetState(new DisabledServiceState());

    public void Destroy(Service service) => 
        service.SetState(new DestroyServiceState());
    
    public void Accept(IServiceStateVisitor visitor) => 
        visitor.Visit(this);
}