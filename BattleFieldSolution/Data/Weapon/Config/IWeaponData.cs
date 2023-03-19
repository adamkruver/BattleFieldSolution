namespace BattleFieldSolution.Data.Weapon.Config;

public interface IWeaponData
{
    string Title { get; }
    int Damage { get; }
    int AttackDelay { get; }
    int ReloadDelay { get; }
    int MaxAmmo { get; }
}