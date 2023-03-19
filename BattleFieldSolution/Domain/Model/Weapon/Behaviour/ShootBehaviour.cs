using BattleFieldSolution.Domain.Model.Unit.Behaviour;

namespace BattleFieldSolution.Domain.Model.Weapon.Behaviour;

public class ShootBehaviour : IWeaponBehaviour
{
    private readonly int _cooldown;

    private int _tickSkip = 0;

    public ShootBehaviour(int cooldown)
    {
        _cooldown = cooldown;
    }

    public IBehaviour<IWeapon>? OnSuccess { get; set; }
    public IBehaviour<IWeapon>? OnFail { get; set; }

    public void Handle(IWeapon weapon)
    {
        if (weapon.CurrentAmmo == 0)
        {
            OnFail?.Handle(weapon);
            return;
        }
        
        _tickSkip++;

        if (_tickSkip < _cooldown)
            return;

        _tickSkip = 0;
        weapon.Shoot();
    }
}