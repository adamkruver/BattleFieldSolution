namespace BattleFieldSolution.Data.Weapon.Config;

public class Rifle: IWeaponData
{
    public string Title { get; } = nameof(Rifle);
    public int Damage { get; } = 100;
    public int AttackDelay { get; } = 300;
    public int ReloadDelay { get; } = 150;
    public int MaxAmmo { get; } = 1;
}