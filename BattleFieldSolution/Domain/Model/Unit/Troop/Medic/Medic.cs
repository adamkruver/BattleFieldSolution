using BattleFieldSolution.Common.Damage;
using BattleFieldSolution.Service.TimeService;

namespace BattleFieldSolution.Domain.Model.Unit.Troop.Medic;

public class Medic : Unit, IMedic
{
    private readonly int _healPoints;

    public Medic(ITimeListener timeListener, int maxHealth, int healPoints) : base(timeListener, maxHealth) =>
        _healPoints = healPoints;

    public void Heal(IHealable target) =>
        target.Heal(_healPoints);
}