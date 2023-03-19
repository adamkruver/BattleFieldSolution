namespace BattleFieldSolution.Data.Weapon.Config;

public class Ak47 : IWeaponData
{
    public string Title { get; } = nameof(Ak47);
    public int Damage { get; } = 27;
    public int AttackDelay { get; } = 50;
    public int ReloadDelay { get; } = 100;
    public int MaxAmmo { get; } = 30;
}