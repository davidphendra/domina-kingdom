using TestA.Elazul.Domains;
using TestA.Elazul.Services;

namespace TestA_UnitTest;

public class ElazulBuilderService_UnitTests
{
    private IElazulBatallionService _elazulBatallionService;
    
    [SetUp]
    public void Setup()
    {
        _elazulBatallionService = new ElazulBatallionService();
    }

    [Test]
    public void Given_1s_1a_1m_1h_ReturnTrue()
    {
        var actual = _elazulBatallionService.Build(new[]
        {
            WarriorClass.Swordmen,
            WarriorClass.Archer,
            WarriorClass.Healer,
            WarriorClass.Mage
        });
        
        Assert.That(actual.Count(), Is.EqualTo(1));
        Assert.That(actual.ElementAt(0).TotalSwordmen, Is.EqualTo(1));
        Assert.That(actual.ElementAt(0).TotalArcher, Is.EqualTo(1));
        Assert.That(actual.ElementAt(0).TotalMage, Is.EqualTo(1));
        Assert.That(actual.ElementAt(0).TotalHealer, Is.EqualTo(1));
    }
    
    [Test]
    public void Given_1s_1a_1m_5h_ReturnTrue()
    {
        var actual = _elazulBatallionService.Build(new[]
        {
            WarriorClass.Swordmen,
            WarriorClass.Archer,
            WarriorClass.Mage,
            WarriorClass.Healer,
            WarriorClass.Healer,
            WarriorClass.Healer,
            WarriorClass.Healer,
            WarriorClass.Healer
        });
        
        Assert.That(actual.Count(), Is.EqualTo(2));
        
        Assert.That(actual.ElementAt(0).TotalSwordmen, Is.EqualTo(1));
        Assert.That(actual.ElementAt(0).TotalArcher, Is.EqualTo(1));
        Assert.That(actual.ElementAt(0).TotalMage, Is.EqualTo(1));
        Assert.That(actual.ElementAt(0).TotalHealer, Is.EqualTo(2));
        
        Assert.That(actual.ElementAt(1).TotalSwordmen, Is.EqualTo(0));
        Assert.That(actual.ElementAt(1).TotalArcher, Is.EqualTo(0));
        Assert.That(actual.ElementAt(1).TotalMage, Is.EqualTo(0));
        Assert.That(actual.ElementAt(1).TotalHealer, Is.EqualTo(3));
    }
    
    [Test]
    public void Given_1s_1a_5m_1h_ReturnTrue()
    {
        var actual = _elazulBatallionService.Build(new[]
        {
            WarriorClass.Swordmen,
            WarriorClass.Archer,
            WarriorClass.Mage,
            WarriorClass.Mage,
            WarriorClass.Mage,
            WarriorClass.Mage,
            WarriorClass.Mage,
            WarriorClass.Healer
        });
        
        Assert.That(actual.Count(), Is.EqualTo(2));
        
        Assert.That(actual.ElementAt(0).TotalSwordmen, Is.EqualTo(1));
        Assert.That(actual.ElementAt(0).TotalArcher, Is.EqualTo(1));
        Assert.That(actual.ElementAt(0).TotalMage, Is.EqualTo(2));
        Assert.That(actual.ElementAt(0).TotalHealer, Is.EqualTo(1));
        
        Assert.That(actual.ElementAt(1).TotalSwordmen, Is.EqualTo(0));
        Assert.That(actual.ElementAt(1).TotalArcher, Is.EqualTo(0));
        Assert.That(actual.ElementAt(1).TotalMage, Is.EqualTo(3));
        Assert.That(actual.ElementAt(1).TotalHealer, Is.EqualTo(0));
    }
    
    [Test]
    public void Given_1s_5a_1m_1h_ReturnTrue()
    {
        var actual = _elazulBatallionService.Build(new[]
        {
            WarriorClass.Swordmen,
            WarriorClass.Archer,
            WarriorClass.Archer,
            WarriorClass.Archer,
            WarriorClass.Archer,
            WarriorClass.Archer,
            WarriorClass.Mage,
            WarriorClass.Healer
        });
        
        Assert.That(actual.Count(), Is.EqualTo(2));
        
        Assert.That(actual.ElementAt(0).TotalSwordmen, Is.EqualTo(1));
        Assert.That(actual.ElementAt(0).TotalArcher, Is.EqualTo(2));
        Assert.That(actual.ElementAt(0).TotalMage, Is.EqualTo(1));
        Assert.That(actual.ElementAt(0).TotalHealer, Is.EqualTo(1));
        
        Assert.That(actual.ElementAt(1).TotalSwordmen, Is.EqualTo(0));
        Assert.That(actual.ElementAt(1).TotalArcher, Is.EqualTo(3));
        Assert.That(actual.ElementAt(1).TotalMage, Is.EqualTo(0));
        Assert.That(actual.ElementAt(1).TotalHealer, Is.EqualTo(0));
    }
    
    [Test]
    public void Given_1s_3a_3m_1h_ReturnTrue()
    {
        var actual = _elazulBatallionService.Build(new[]
        {
            WarriorClass.Swordmen,
            WarriorClass.Archer,
            WarriorClass.Archer,
            WarriorClass.Archer,
            WarriorClass.Mage,
            WarriorClass.Mage,
            WarriorClass.Mage,
            WarriorClass.Healer
        });
        
        Assert.That(actual.Count(), Is.EqualTo(2));
        
        Assert.That(actual.ElementAt(0).TotalSwordmen, Is.EqualTo(1));
        Assert.That(actual.ElementAt(0).TotalArcher, Is.EqualTo(2));
        Assert.That(actual.ElementAt(0).TotalMage, Is.EqualTo(1));
        Assert.That(actual.ElementAt(0).TotalHealer, Is.EqualTo(1));
        
        Assert.That(actual.ElementAt(1).TotalSwordmen, Is.EqualTo(0));
        Assert.That(actual.ElementAt(1).TotalArcher, Is.EqualTo(1));
        Assert.That(actual.ElementAt(1).TotalMage, Is.EqualTo(2));
        Assert.That(actual.ElementAt(1).TotalHealer, Is.EqualTo(0));
    }
    
    [Test]
    public void Given_10s_6a_3m_5h_ReturnTrue()
    {
        var actual = _elazulBatallionService.Build(new[]
        {
            WarriorClass.Swordmen,
            WarriorClass.Swordmen,
            WarriorClass.Swordmen,
            WarriorClass.Swordmen,
            WarriorClass.Swordmen,
            WarriorClass.Swordmen,
            WarriorClass.Swordmen,
            WarriorClass.Swordmen,
            WarriorClass.Swordmen,
            WarriorClass.Swordmen,
            
            WarriorClass.Archer,
            WarriorClass.Archer,
            WarriorClass.Archer,
            WarriorClass.Archer,
            WarriorClass.Archer,
            WarriorClass.Archer,
            
            WarriorClass.Healer,
            WarriorClass.Healer,
            WarriorClass.Healer,
            WarriorClass.Healer,
            WarriorClass.Healer,
            
            WarriorClass.Mage,
            WarriorClass.Mage,
            WarriorClass.Mage
        });
        
        Assert.That(actual.Count(), Is.EqualTo(5));
        
        Assert.That(2, Is.EqualTo(actual.First().TotalSwordmen));
        Assert.That(1, Is.EqualTo(actual.First().TotalArcher));
        Assert.That(1, Is.EqualTo(actual.First().TotalMage));
        Assert.That(1, Is.EqualTo(actual.First().TotalHealer));
        
        Assert.That(2, Is.EqualTo(actual.ElementAt(1).TotalSwordmen));
        Assert.That(1, Is.EqualTo(actual.ElementAt(1).TotalArcher));
        Assert.That(1, Is.EqualTo(actual.ElementAt(1).TotalMage));
        Assert.That(1, Is.EqualTo(actual.ElementAt(1).TotalHealer));
        
        Assert.That(2, Is.EqualTo(actual.ElementAt(2).TotalSwordmen));
        Assert.That(1, Is.EqualTo(actual.ElementAt(2).TotalArcher));
        Assert.That(1, Is.EqualTo(actual.ElementAt(2).TotalMage));
        Assert.That(1, Is.EqualTo(actual.ElementAt(2).TotalHealer));
        
        Assert.That(2, Is.EqualTo(actual.ElementAt(3).TotalSwordmen));
        Assert.That(2, Is.EqualTo(actual.ElementAt(3).TotalArcher));
        Assert.That(0, Is.EqualTo(actual.ElementAt(3).TotalMage));
        Assert.That(1, Is.EqualTo(actual.ElementAt(3).TotalHealer));
        
        Assert.That(2, Is.EqualTo(actual.ElementAt(4).TotalSwordmen));
        Assert.That(1, Is.EqualTo(actual.ElementAt(4).TotalArcher));
        Assert.That(0, Is.EqualTo(actual.ElementAt(4).TotalMage));
        Assert.That(1, Is.EqualTo(actual.ElementAt(4).TotalHealer));
    }
}