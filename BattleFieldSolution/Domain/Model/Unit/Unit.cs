using BattleFieldSolution.Common.Attack;
using BattleFieldSolution.Common.Damage;
using BattleFieldSolution.Domain.Model.Unit.Behaviour;
using BattleFieldSolution.Domain.Model.Unit.Behaviour.State;
using BattleFieldSolution.Domain.Model.Unit.HealthModel;
using BattleFieldSolution.Service.TimeService;

namespace BattleFieldSolution.Domain.Model.Unit;

public abstract class Unit : UnitBehaviour, IDamageable
{
    private static int _ids;

    private readonly Health _health;
    protected int Id;

    public Unit(ITimeListener timeListener, int maxHealth) : base(timeListener)
    {
        _health = new Health(maxHealth);
        _health.Died += OnDied;
        Id = ++_ids;
    }

    public event Action<IDamageable>? Died;

    public AttackResult TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
        return new AttackResult(this);
    }

    protected void ApplyHeal(int points) =>
        _health.Heal(points);

    private void OnDied(IDamageable damageable)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{Id} id Dead");
        Console.ForegroundColor = ConsoleColor.White;
        _health.Died -= OnDied;
        SetState(new DestroyBehaviorState());
        Died?.Invoke(this);
    }
}