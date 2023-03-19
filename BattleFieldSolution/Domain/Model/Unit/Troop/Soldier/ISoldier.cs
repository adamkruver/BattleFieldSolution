using BattleFieldSolution.Common.Attack;
using BattleFieldSolution.Domain.Model.Weapon;

namespace BattleFieldSolution.Domain.Model.Unit.Troop.Soldier;

public interface ISoldier: IAttack
{
    void Add(IWeapon weapon);
}