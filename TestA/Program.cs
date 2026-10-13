using TestA.Elazul.Domains;
using TestA.Elazul.Services;

IReadOnlyCollection<WarriorClass> BuildUserWarrior(UserInput userInput)
{
    var warriors = new List<WarriorClass>();
    if (userInput.TotalSwordmen > 0)
    {
        warriors.AddRange(Enumerable.Range(0, userInput.TotalSwordmen).Select(x => WarriorClass.Swordmen));
    }
    
    if (userInput.TotalArcher > 0)
    {
        warriors.AddRange(Enumerable.Range(0, userInput.TotalArcher).Select(x => WarriorClass.Archer));
    }
    
    if (userInput.TotalMage > 0)
    {
        warriors.AddRange(Enumerable.Range(0, userInput.TotalMage).Select(x => WarriorClass.Mage));
    }
    
    if (userInput.TotalHealer > 0)
    {
        warriors.AddRange(Enumerable.Range(0, userInput.TotalHealer).Select(x => WarriorClass.Healer));
    }

    return warriors;
}

var userSetting = new UserInput();

Console.Write("Input Total Swordmen: ");
var userInput = Console.ReadLine();

if (int.TryParse(userInput, out int inputWarrior))
{
    userSetting.TotalSwordmen = inputWarrior;
}

Console.Write("Input Total Archer: ");
userInput = Console.ReadLine();

if (int.TryParse(userInput, out inputWarrior))
{
    userSetting.TotalArcher = inputWarrior;
}

Console.Write("Input Total Mage: ");
userInput = Console.ReadLine();

if (int.TryParse(userInput, out inputWarrior))
{
    userSetting.TotalMage = inputWarrior;
}

Console.Write("Input Total Healer: ");
userInput = Console.ReadLine();

if (int.TryParse(userInput, out inputWarrior))
{
    userSetting.TotalHealer = inputWarrior;
}

var userWarriors = BuildUserWarrior(userSetting);
var elazulBatallionService = new ElazulBatallionService();
var dragonBatallions= elazulBatallionService.Build(userWarriors);

foreach (var dragonBatallion in dragonBatallions)
{
    Console.WriteLine($"Dragon {dragonBatallion.Id}: {dragonBatallion.TotalSwordmen} swordsmen, {dragonBatallion.TotalArcher} archers, {dragonBatallion.TotalMage} mages, {dragonBatallion.TotalHealer} healers");
}
