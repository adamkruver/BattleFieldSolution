using BattleFieldSolution.Domain.Model.Unit.Troop.Medic.Factory;
using BattleFieldSolution.Domain.Model.Unit.Troop.Soldier.Factory;
using BattleFieldSolution.Domain.Model.Weapon;
using BattleFieldSolution.Domain.Model.Weapon.Factory;

namespace BattleFieldSolution.Domain.Model.Unit.Troop.Soldier.Builder;

public class SoldierBuilder
{
    private readonly SoldierFactory _soldierFactory;
    private readonly MedicFactory _medicFactory;
    private readonly WeaponFactory _weaponFactory;

    public SoldierBuilder(
        SoldierFactory soldierFactory,
        MedicFactory medicFactory,
        WeaponFactory weaponFactory
    )
    {
        _soldierFactory = soldierFactory;
        _medicFactory = medicFactory;
        _weaponFactory = weaponFactory;
    }

    public Soldier BuildSniper()
    {
        Soldier soldier = _soldierFactory.Create();
        IWeapon sniperRifle = _weaponFactory.CreateSniperRifle();
        
        soldier.Add(sniperRifle);
        
        return soldier;
    }

    public Soldier BuildSoldier()
    {
        Soldier soldier = _soldierFactory.Create();
        IWeapon ak47 = _weaponFactory.CreateAk47();
        
        soldier.Add(ak47);
        
        return soldier;
    }

    public Medic.Medic BuildMedic()
    {
        Medic.Medic medic = _medicFactory.Create();
        
        return medic;
    }
}