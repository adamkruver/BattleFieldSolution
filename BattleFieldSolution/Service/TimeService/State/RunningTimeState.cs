namespace BattleFieldSolution.Service.TimeService.State;

public class RunningTimeState : ITimeState
{
    public void Tick(TimeService timeService) =>
        timeService.Update();
}