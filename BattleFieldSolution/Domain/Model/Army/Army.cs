using BattleFieldSolution.Common.Attack;
using BattleFieldSolution.Common.Damage;

namespace BattleFieldSolution.Domain.Model.Army;

public class Army : IDamageable
{
    private readonly List<Unit.Unit> _units = new List<Unit.Unit>();

    private IDamageable _target;

    public Army(string name)
    {
        Name = name;
    }

    public event Action<IDamageable>? Died;

    public string Name { get; }
    
    private IAttack[] AttackUnits => _units
        .Select(unit => unit as IAttack)
        .Where(unit => unit != null)
        .ToArray();
    
    public void SetTarget(IDamageable target)
    {
        _target = target;
    }

    public void Attack()
    {
        foreach (var unit in AttackUnits)
            unit.Attack(_target);
    }

    public void Add(Unit.Unit unit)
    {
        if (_units.Contains(unit))
            return;
        
        _units.Add(unit);
        unit.Died += OnUnitDied;
    }

    private void OnUnitDied(IDamageable unit)
    {
        Console.WriteLine("Unit died");
        
        if (unit is Unit.Unit diedUnit == false)
            return;

        diedUnit.Died -= OnUnitDied;
        _units.Remove(diedUnit);

        if (AttackUnits.Length == 0)
            Died?.Invoke(this);
    }

    public AttackResult TakeDamage(int damage)
    {
        if (AttackUnits.Length == 0)
            return new AttackResult(null);

        Unit.Unit unit = GetRandomUnit();
        unit.TakeDamage(damage);
        return new AttackResult(unit);
    }

    private Unit.Unit GetRandomUnit()
    {
        
        Random random = new Random();

        return _units[random.Next(_units.Count)];
    }

    private IAttack GetRandomAttackUnit()
    {
        IAttack[] attackUnits = AttackUnits;
        Random random = new Random();

        return AttackUnits[random.Next(attackUnits.Length)];
    }

}