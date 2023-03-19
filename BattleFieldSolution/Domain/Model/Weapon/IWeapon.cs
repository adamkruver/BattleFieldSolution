using BattleFieldSolution.Common.Attack;
using BattleFieldSolution.Common.Damage;
using BattleFieldSolution.Domain.Model.Weapon.Behaviour;

namespace BattleFieldSolution.Domain.Model.Weapon;

public interface IWeapon : IAttack
{
    void SetTarget(IDamageable target);
    AttackResult Fire();
    bool TryReload();

    void Shoot();
    void AddAmmo(int ammo);
    int CurrentAmmo { get; }
    int AvailableAmmo { get; }
    IWeaponBehaviour ShootBehaviour { get; }
}