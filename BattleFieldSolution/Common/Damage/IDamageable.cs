using BattleFieldSolution.Common.Attack;

namespace BattleFieldSolution.Common.Damage;

public interface IDamageable
{
    AttackResult TakeDamage(int damage);
    event Action<IDamageable>? Died;
}