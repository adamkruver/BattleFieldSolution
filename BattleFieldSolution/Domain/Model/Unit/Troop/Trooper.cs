using BattleFieldSolution.Common.Damage;
using BattleFieldSolution.Service.TimeService;

namespace BattleFieldSolution.Domain.Model.Unit.Troop;

public abstract class Trooper: Unit, IHealable
{
    public Trooper(ITimeListener timeListener, int maxHealth) : base(timeListener, maxHealth)
    {
    }
    
    public void Heal(int points) => 
        ApplyHeal(points);
}