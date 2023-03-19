using BattleFieldSolution.Data.Weapon.Config;

namespace BattleFieldSolution.Domain.Model.Weapon.Factory;

public class WeaponFactory
{
    private readonly WeaponConfig _weaponConfig;

    public WeaponFactory(WeaponConfig weaponConfig)
    {
        _weaponConfig = weaponConfig;
    }

    public IWeapon CreateSniperRifle() => 
        new Weapon(_weaponConfig.Rifle);
    
    public IWeapon CreateAk47() => 
        new Weapon(_weaponConfig.Ak47);
}