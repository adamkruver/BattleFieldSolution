using BattleFieldSolution.Common.Attack;
using BattleFieldSolution.Common.Damage;
using BattleFieldSolution.Data.Weapon.Config;
using BattleFieldSolution.Domain.Model.Weapon.Behaviour;

namespace BattleFieldSolution.Domain.Model.Weapon;

public class Weapon : IWeapon
{
    private readonly IWeaponData _weaponData;

    private IDamageable _target;
    private readonly IWeaponBehaviour _reloadBehaviour;

    private AttackResult _attackResult;

    public Weapon(IWeaponData weaponData)
    {
        _weaponData = weaponData;
        
        ShootBehaviour = new ShootBehaviour(weaponData.AttackDelay);
        _reloadBehaviour = new ReloadBehaviour(weaponData.ReloadDelay);
        ShootBehaviour.OnFail = _reloadBehaviour;
        _reloadBehaviour.OnSuccess = ShootBehaviour;
    }

    public string Title => _weaponData.Title;
    public int Damage => _weaponData.Damage;
    public int MaxAmmo => _weaponData.MaxAmmo;
    public int CurrentAmmo { get; private set; }
    public int AvailableAmmo { get; private set; } = 0;
    public IWeaponBehaviour ShootBehaviour { get; }

    public void AddAmmo(int ammo) => 
        AvailableAmmo += ammo;

    public void Attack(IDamageable damageable) =>
        damageable.TakeDamage(Damage);

    public void SetTarget(IDamageable target) =>
        _target = target;

    public AttackResult Fire()
    {
        ShootBehaviour.Handle(this);
        
        AttackResult attackResult = _attackResult;
        _attackResult = null;
        
        return attackResult;
    }

    public void Shoot()
    {
        if (_target == null)
            return;
        
        _attackResult = _target.TakeDamage(Damage);
        CurrentAmmo--;
    }

    public bool TryReload()
    {
        AvailableAmmo -= MaxAmmo;

        int ammo = MaxAmmo + (AvailableAmmo < 0 ? AvailableAmmo : 0);
        
        if(AvailableAmmo < 0)
            AvailableAmmo = 0;

        if (ammo <= 0)
        {
            CurrentAmmo = 0;
            return false;
        }
        
        CurrentAmmo = ammo;
        return true;
    }
}