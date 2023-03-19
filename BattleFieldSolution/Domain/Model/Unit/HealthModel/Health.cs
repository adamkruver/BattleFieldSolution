using BattleFieldSolution.Common.Attack;
using BattleFieldSolution.Common.Damage;

namespace BattleFieldSolution.Domain.Model.Unit.HealthModel;

public class Health : IDamageable, IHealable
{
    private readonly int _min = 0;
    private readonly int _max;

    private int _value;

    public Health(int max)
    {
        _max = max;
        _value = max;
    }

    public event Action<IDamageable>? Died;

    public AttackResult TakeDamage(int damage)
    {
        if (damage <= 0)
            return null;

        _value -= damage;

        if (_value < _min)
            _value = _min;

        if (_value == _min)
            Died?.Invoke(this);

        return null;
    }

    public void Heal(int points)
    {
        if (points <= 0)
            return;

        _value += points;

        if (_value > _max)
            _value = _max;
    }
}