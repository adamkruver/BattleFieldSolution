namespace BattleFieldSolution.Service.State;

public interface IServiceStateVisitor
{
    void Visit(EnabledServiceState serviceState);
    void Visit(DisabledServiceState serviceState);
    void Visit(InitServiceState serviceState);
    void Visit(DestroyServiceState serviceState);
}