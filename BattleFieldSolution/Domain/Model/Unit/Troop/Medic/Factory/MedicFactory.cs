using BattleFieldSolution.Data.Soldier.Config;
using BattleFieldSolution.Service.TimeService;

namespace BattleFieldSolution.Domain.Model.Unit.Troop.Medic.Factory;

public class MedicFactory
{
    private readonly ITimeListener _timeListener;
    private readonly TroopersConfig _troopersConfig;

    public MedicFactory(ITimeListener timeListener, TroopersConfig troopersConfig)
    {
        _timeListener = timeListener;
        _troopersConfig = troopersConfig;
    }

    public Medic Create() =>
        new Medic(_timeListener, _troopersConfig.Medic.Health, _troopersConfig.Medic.HealPoints);
}