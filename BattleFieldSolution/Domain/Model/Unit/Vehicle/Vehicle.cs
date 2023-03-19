using BattleFieldSolution.Service.TimeService;

namespace BattleFieldSolution.Domain.Model.Unit.Vehicle;

public abstract class Vehicle : Unit, IRepairable

{
    public Vehicle(ITimeListener timeListener, int maxHealth) : base(timeListener, maxHealth)
    {
    }

    public void Repair(int points) =>
        ApplyHeal(points);
}