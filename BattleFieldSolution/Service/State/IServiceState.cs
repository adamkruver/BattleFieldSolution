using BattleFieldSolution.Service.TimeService;

namespace BattleFieldSolution.Service.State;

public interface IServiceState
{
    void Enable(Service service);
    void Disable(Service service);
    void Destroy(Service service);
    void Accept(IServiceStateVisitor visitor);
}