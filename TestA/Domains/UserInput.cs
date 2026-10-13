namespace TestA.Elazul.Domains;

public record UserInput
{
    public int TotalSwordmen { get; set; }

    public bool HasUnseatedSwordmen => TotalSwordmen > 0;
    
    public int TotalArcher { get; set; }
    
    public bool HasUnseatedArcher => TotalArcher > 0;
    
    public int TotalMage { get; set; }
    
    public bool HasUnseatedMage => TotalArcher > 0;
    
    public int TotalHealer { get; set; }
    
    public bool HasUnseatedHealer => TotalArcher > 0;
    
    public bool HasUnseatedWarrior => HasUnseatedArcher && HasUnseatedArcher && HasUnseatedMage && HasUnseatedHealer;
}