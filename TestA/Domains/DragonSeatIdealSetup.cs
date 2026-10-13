namespace TestA.Elazul.Domains;

public static class DragonSeatIdealSetup
{
    public const int TotalSeat = 5;

    public const int TotalSwordmen = 1;

    public const int TotalArcher = 1;

    public const int TotalMage = 1;

    public const int TotalHealer = 1;

    public static WarriorClass[] Priorities { get; } =
    [
        WarriorClass.Swordmen,
        WarriorClass.Archer,
        WarriorClass.Mage,
        WarriorClass.Healer
    ];
}