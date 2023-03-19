namespace BattleFieldSolution.Domain.Model.Army.Factory;

public class ArmyFactory
{
    public Army Create(string name)
    {
        return new Army(name);
    }
}