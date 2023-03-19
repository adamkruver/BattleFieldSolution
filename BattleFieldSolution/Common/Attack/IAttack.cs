using BattleFieldSolution.Common.Damage;

namespace BattleFieldSolution.Common.Attack;

public interface IAttack
{
    void Attack(IDamageable damageable);
}