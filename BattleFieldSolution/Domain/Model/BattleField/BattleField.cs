using BattleFieldSolution.Common.Damage;
using BattleFieldSolution.Domain.Model.Army.Builder;

namespace BattleFieldSolution.Domain.Model.BattleField;

public class BattleField
{
    private readonly ArmyBuilder _armyBuilder;

    private Army.Army _firstArmy;
    private Army.Army _secondArmy;
    
    public BattleField(ArmyBuilder armyBuilder)
    {
        _armyBuilder = armyBuilder;
    }

    public void StartBattle()
    {
        _firstArmy = _armyBuilder.Build("Первая армия");
        _secondArmy = _armyBuilder.Build("Вторая армия");
        Battle();
    }

    private void Battle()
    {
        _firstArmy.SetTarget(_secondArmy);
        _secondArmy.SetTarget(_firstArmy);

        _firstArmy.Died += OnArmyFailed;
        _secondArmy.Died += OnArmyFailed;
        
        _secondArmy.Attack();
        _firstArmy.Attack();
    }

    private void OnArmyFailed(IDamageable army)
    {
        if (army is Army.Army firedArmy)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Проиграла армия: {firedArmy.Name}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        
        _firstArmy.Died -= OnArmyFailed;
        _secondArmy.Died -= OnArmyFailed;        
    }
}