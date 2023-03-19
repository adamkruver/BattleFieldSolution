using BattleFieldSolution.Domain.Model.Unit.Behaviour;

namespace BattleFieldSolution.Domain.Model.Weapon.Behaviour;

public class ReloadBehaviour:IWeaponBehaviour
{
    private readonly int _reloadTime;

    private int _timeSkip = 0;

    public ReloadBehaviour(int reloadTime)
    {
        Random random = new Random();
        _reloadTime = reloadTime + random.Next(5);
    }

    public IBehaviour<IWeapon>? OnSuccess { get; set; }
    public IBehaviour<IWeapon>? OnFail { get; set; }
    
    public void Handle(IWeapon weapon)
    {
        _timeSkip++;

        if (_timeSkip < _reloadTime)
            return;

        if (weapon.TryReload() == false)
            OnFail?.Handle(weapon);
    }
}