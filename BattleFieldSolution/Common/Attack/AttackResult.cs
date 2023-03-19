using BattleFieldSolution.Common.Damage;

namespace BattleFieldSolution.Common.Attack;

public class AttackResult
{
    public IDamageable Target { get; }

    public AttackResult(IDamageable target)
    {
        Target = target;
    }
}