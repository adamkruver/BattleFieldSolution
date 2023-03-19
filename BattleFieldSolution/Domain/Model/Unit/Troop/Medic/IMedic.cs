using BattleFieldSolution.Common.Damage;

namespace BattleFieldSolution.Domain.Model.Unit.Troop.Medic;

public interface IMedic
{
    void Heal(IHealable target);
}