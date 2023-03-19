using BattleFieldSolution.Service.TimeService;

namespace BattleFieldSolution.Service.State;

public class AwakeServiceState : IServiceState
{
    public void Enable(Service service)
    {
        service.SetState(new InitServiceState());
        service.SetState(new EnabledServiceState());
    }

    public void Disable(Service service) { }

    public void Destroy(Service service) { }

    public void Accept(IServiceStateVisitor visitor) { }
}