using BattleFieldSolution.Data.Soldier.Config;
using BattleFieldSolution.Service.TimeService;

namespace BattleFieldSolution.Domain.Model.Unit.Troop.Soldier.Factory;

public class SoldierFactory
{
    private readonly ITimeListener _timeListener;
    private readonly TroopersConfig _troopersConfig;

    public SoldierFactory(ITimeListener timeListener, TroopersConfig troopersConfig)
    {
        _timeListener = timeListener;
        _troopersConfig = troopersConfig;
    }

    public Soldier Create() =>
        new Soldier(_timeListener, _troopersConfig.Soldier);
}