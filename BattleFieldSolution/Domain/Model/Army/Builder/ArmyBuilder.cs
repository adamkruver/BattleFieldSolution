using BattleFieldSolution.Data.Army.Config;
using BattleFieldSolution.Domain.Model.Army.Factory;
using BattleFieldSolution.Domain.Model.Unit.Troop.Soldier;
using BattleFieldSolution.Domain.Model.Unit.Troop.Soldier.Builder;

namespace BattleFieldSolution.Domain.Model.Army.Builder;

public class ArmyBuilder
{
    private readonly ArmyFactory _armyFactory;
    private readonly SoldierBuilder _soldierBuilder;
    private readonly ArmyConfig _armyConfig;

    public ArmyBuilder(
        ArmyFactory armyFactory, 
        SoldierBuilder soldierBuilder,
        ArmyConfig armyConfig
    )
    {
        _armyFactory = armyFactory;
        _soldierBuilder = soldierBuilder;
        _armyConfig = armyConfig;
    }

    public Army Build(string name)
    {
        Army army = _armyFactory.Create(name);
        
        AddSoldiers(army, CreateSoldiers(_soldierBuilder.BuildSniper,_armyConfig.SniperCount));
        AddSoldiers(army, CreateSoldiers(_soldierBuilder.BuildMedic,_armyConfig.MedicCount));
        AddSoldiers(army, CreateSoldiers(_soldierBuilder.BuildSoldier,_armyConfig.TrooperCount));
        
        return army;
    }

    private void AddSoldiers(Army army, Unit.Unit[] soldiers)
    {
        foreach (Unit.Unit soldier in soldiers) 
            army.Add(soldier);
    }

    private Unit.Unit[] CreateSoldiers(Func<Unit.Unit> creator, int count)
    {
        List<Unit.Unit> soldiers = new List<Unit.Unit>();
        
        for (int i = 0; i < count; i++) 
            soldiers.Add(creator.Invoke());

        return soldiers.ToArray();
    }
}