using BattleFieldSolution.Service.State;
using BattleFieldSolution.Service.TimeService.State;

namespace BattleFieldSolution.Service.TimeService;

public class TimeService : Service, ITimeListener
{
    private ITimeState _timeState;
    private int _tickDelay = 1;

    public TimeService()
    {
        StateChanged += OnStateChanged;
    }

    public event Action<ulong>? Ticked;

    public ulong Time { get; private set; }

    public void Update()
    {
        Time++;
        Ticked?.Invoke(Time);
    }

    private void OnStateChanged(IServiceState serviceState)
    {
        Console.WriteLine(serviceState.GetType());
        serviceState.Accept(this);
    }

    private void Tick() =>
        _timeState.Tick(this);

    public void Visit(EnabledServiceState serviceState) =>
        _timeState = new RunningTimeState();

    public void Visit(DisabledServiceState serviceState) =>
        _timeState = new StoppedTimeState();

    public void Visit(InitServiceState serviceState)
    {
        Task.Run(async () =>
        {
            while (_timeState is not DestroyServiceState)
            {
                Tick();
                await Task.Delay(_tickDelay);
            }
        });
    }

    public void Visit(DestroyServiceState serviceState)
    {
        _timeState = new DestroyTimeState();
        StateChanged -= OnStateChanged;
    }
}