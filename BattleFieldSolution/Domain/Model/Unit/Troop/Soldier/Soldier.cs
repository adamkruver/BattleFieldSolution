using BattleFieldSolution.Common.Attack;
using BattleFieldSolution.Common.Damage;
using BattleFieldSolution.Data.Soldier.Config;
using BattleFieldSolution.Domain.Model.Unit.Behaviour;
using BattleFieldSolution.Domain.Model.Unit.Behaviour.State;
using BattleFieldSolution.Domain.Model.Weapon;
using BattleFieldSolution.Service.TimeService;

namespace BattleFieldSolution.Domain.Model.Unit.Troop.Soldier;

public class Soldier : Trooper, ISoldier
{
    
    private readonly SoldierConfig _soldierConfig;
    private readonly List<IWeapon> _weapons = new List<IWeapon>();

    private IDamageable _target;
    
    public Soldier(ITimeListener timeListener, SoldierConfig soldierConfig) : base(timeListener, soldierConfig.Health)
    {
        _soldierConfig = soldierConfig;
    }

    public override void Update(ulong time)
    {
        foreach (var weapon in _weapons)
        {
            if (weapon.CurrentAmmo != 0 || weapon.AvailableAmmo != 0)
            {
                weapon.SetTarget(_target);
                AttackResult result = weapon.Fire();

                if (result != null)
                {
                    if (result.Target is null)
                    {
                        Disable();
                    }
                }
                return;
            }
        }
        
        Disable();
    }

    public void Attack(IDamageable target)
    {
        _target = target;
        Enable();
    }

    public void Add(IWeapon weapon)
    {
        if (_weapons.Contains(weapon))
            return;

        _weapons.Add(weapon);
        weapon.AddAmmo(_soldierConfig.Ammo);
    }
}