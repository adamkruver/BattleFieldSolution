using BattleFieldSolution.Data.Army.Config;
using BattleFieldSolution.Data.Soldier.Config;
using BattleFieldSolution.Data.Weapon.Config;
using BattleFieldSolution.Domain.Model.Army.Builder;
using BattleFieldSolution.Domain.Model.Army.Factory;
using BattleFieldSolution.Domain.Model.BattleField;
using BattleFieldSolution.Domain.Model.Unit.Troop.Medic.Factory;
using BattleFieldSolution.Domain.Model.Unit.Troop.Soldier.Builder;
using BattleFieldSolution.Domain.Model.Unit.Troop.Soldier.Factory;
using BattleFieldSolution.Domain.Model.Weapon.Factory;
using BattleFieldSolution.Service.TimeService;

namespace BattleFieldSolution;

public static class Program
{
    public static void Main()
    {
        TimeService timeService = new TimeService();
        timeService.Enable();

        TroopersConfig troopersConfig = new TroopersConfig();
        WeaponConfig weaponConfig = new WeaponConfig();
        ArmyConfig armyConfig = new ArmyConfig();
        ArmyFactory armyFactory = new ArmyFactory();
        MedicFactory medicFactory = new MedicFactory(timeService, troopersConfig);
        WeaponFactory weaponFactory = new WeaponFactory(weaponConfig);
        SoldierFactory soldierFactory = new SoldierFactory(timeService, troopersConfig);
        SoldierBuilder soldierBuilder = new SoldierBuilder(soldierFactory, medicFactory, weaponFactory);
        ArmyBuilder armyBuilder = new ArmyBuilder(armyFactory, soldierBuilder, armyConfig);
        BattleField battleField = new BattleField(armyBuilder);

        battleField.StartBattle();

        while (Console.KeyAvailable == false);
        
        timeService.Destroy();
    }
}