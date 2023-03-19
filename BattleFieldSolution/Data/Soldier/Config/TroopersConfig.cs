namespace BattleFieldSolution.Data.Soldier.Config;

public class TroopersConfig
{
    public SoldierConfig Soldier { get; } = new SoldierConfig();
    public MedicConfig Medic { get; } = new MedicConfig();
}