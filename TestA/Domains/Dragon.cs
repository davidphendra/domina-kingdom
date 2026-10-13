namespace TestA.Elazul.Domains;

public record Dragon
{
    public int Id { get; set; }

    public IList<WarriorClass> Passengers { get; set; } = new List<WarriorClass>();

    public int TotalSwordmen => Passengers?.Count(x => x == WarriorClass.Swordmen) ?? 0;
    
    public int TotalArcher => Passengers?.Count(x => x == WarriorClass.Archer) ?? 0;
    
    public int TotalMage => Passengers?.Count(x => x == WarriorClass.Mage) ?? 0;
    
    public int TotalHealer => Passengers?.Count(x => x == WarriorClass.Healer) ?? 0;
    
    public int TotalWarrior(WarriorClass warriorClass) => Passengers?.Count(x => x == warriorClass) ?? 0;
}