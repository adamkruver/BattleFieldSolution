namespace BattleFieldSolution.Common.Factory;

public interface IFactory<out T>
{
    T Create();
}