using BattleFieldSolution.Service.TimeService;

namespace BattleFieldSolution.Service.State;

public class InitServiceState : IServiceState
{
    public void Enable(Service service) { }

    public void Disable(Service service) { }

    public void Destroy(Service service) { }
    
    public void Accept(IServiceStateVisitor visitor) => 
        visitor.Visit(this);
}