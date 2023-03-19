using BattleFieldSolution.Service.State;

namespace BattleFieldSolution.Service.TimeService;

public interface ITimeListener : IServiceStateVisitor
{
    event Action<ulong>? Ticked;
    ulong Time { get; }
}