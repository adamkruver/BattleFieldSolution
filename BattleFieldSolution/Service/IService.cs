using BattleFieldSolution.Service.State;

namespace BattleFieldSolution.Service;

public interface IService
{
    event Action<IServiceState>? StateChanged;
    void Enable();
    void Disable();
    void Destroy();
}