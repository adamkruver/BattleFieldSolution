using BattleFieldSolution.Service.State;

namespace BattleFieldSolution.Service;

public abstract class Service : IService
{
    private IServiceState _serviceState;

    public Service() =>
        SetState(new AwakeServiceState());

    public event Action<IServiceState>? StateChanged;

    public void Enable() =>
        _serviceState.Enable(this);

    public void Disable() =>
        _serviceState.Disable(this);

    public void Destroy() =>
        _serviceState.Destroy(this);

    public void SetState(IServiceState serviceState)
    {
        _serviceState = serviceState;
        StateChanged?.Invoke(serviceState);
    }
}