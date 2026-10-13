using TestA.Elazul.Domains;
using TestA.Elazul.Extensions;

namespace TestA.Elazul.Services;

public class ElazulBatallionService : IElazulBatallionService
{
    public IReadOnlyCollection<Dragon> Build(IReadOnlyCollection<WarriorClass> warriorInput)
    {
        var dragons = new List<Dragon>();
        var id = 0;

        while (HasUnseatedWarrior(warriorInput, dragons))
        {
            id++;
            var currentDragon = new Dragon { Id = id };

            // populate on ideal setup 
            if (currentDragon.Passengers.Count(x => x == WarriorClass.Swordmen) < DragonSeatIdealSetup.TotalSwordmen 
                && currentDragon.TotalWarrior(WarriorClass.Swordmen) < warriorInput.TotalWarrior(WarriorClass.Swordmen)
                && dragons.SelectMany(x => x.Passengers.Where(x => x == WarriorClass.Swordmen)).Count() < warriorInput.TotalWarrior(WarriorClass.Swordmen))
            {
                currentDragon.Passengers.Add(WarriorClass.Swordmen);
            }
            
            if (currentDragon.Passengers.Count(x => x == WarriorClass.Archer) < DragonSeatIdealSetup.TotalArcher 
                && currentDragon.TotalWarrior(WarriorClass.Archer) < warriorInput.TotalWarrior(WarriorClass.Archer)
                && dragons.SelectMany(x => x.Passengers.Where(x => x == WarriorClass.Archer)).Count() < warriorInput.TotalWarrior(WarriorClass.Archer))
            {
                currentDragon.Passengers.Add(WarriorClass.Archer);
            }
            
            if (currentDragon.Passengers.Count(x => x == WarriorClass.Mage) < DragonSeatIdealSetup.TotalMage 
                && currentDragon.TotalWarrior(WarriorClass.Mage) < warriorInput.TotalWarrior(WarriorClass.Mage)
                && dragons.SelectMany(x => x.Passengers.Where(x => x == WarriorClass.Mage)).Count() < warriorInput.TotalWarrior(WarriorClass.Mage))
            {
                currentDragon.Passengers.Add(WarriorClass.Mage);
            }
            
            if (currentDragon.Passengers.Count(x => x == WarriorClass.Healer) < DragonSeatIdealSetup.TotalHealer 
                && currentDragon.TotalWarrior(WarriorClass.Healer) < warriorInput.TotalWarrior(WarriorClass.Healer)
                && dragons.SelectMany(x => x.Passengers.Where(x => x == WarriorClass.Healer)).Count() < warriorInput.TotalWarrior(WarriorClass.Healer))
            {
                currentDragon.Passengers.Add(WarriorClass.Healer);
            }
            
            dragons.Add(currentDragon);
            
            // populate on priorities
            if (DragonSeatIdealSetup.TotalSeat > currentDragon.Passengers.Count()
                && warriorInput.Count() > currentDragon.Passengers.Count())
            {
                foreach (var warriorClass in DragonSeatIdealSetup.Priorities)
                {
                    if (DragonSeatIdealSetup.TotalSeat <= currentDragon.Passengers.Count())
                        break;
                    
                    if (warriorInput.TotalWarrior(warriorClass) > dragons.SelectMany(x => x.Passengers.Where(x => x == warriorClass)).Count())
                        currentDragon.Passengers.Add(warriorClass);
                }
            }
            
            // populate on remaining 
            if (DragonSeatIdealSetup.TotalSeat > currentDragon.Passengers.Count()
                && warriorInput.Count() > currentDragon.Passengers.Count() )
            {
                while (DragonSeatIdealSetup.TotalSeat > currentDragon.Passengers.Count()
                       && warriorInput.Count() > currentDragon.Passengers.Count()
                       && warriorInput.Count() > dragons.SelectMany(x => x.Passengers).Count())
                {
                    foreach (var warriorClass in DragonSeatIdealSetup.Priorities)
                    {
                        if (DragonSeatIdealSetup.TotalSeat <= currentDragon.Passengers.Count())
                            break;
                        
                        if (warriorInput.TotalWarrior(warriorClass) > dragons.SelectMany(x => x.Passengers.Where(x => x == warriorClass)).Count())
                            currentDragon.Passengers.Add(warriorClass);
                    }
                }
            }
        }

        return dragons;
    }

    private bool HasUnseatedWarrior(
        IReadOnlyCollection<WarriorClass> warriorInput,
        IReadOnlyCollection<Dragon> dragons)
        => warriorInput.TotalWarrior(WarriorClass.Swordmen) > dragons.SelectMany(x => x.Passengers.Where(x => x == WarriorClass.Swordmen)).Count() 
           || warriorInput.TotalWarrior(WarriorClass.Archer) > dragons.SelectMany(x => x.Passengers.Where(x => x == WarriorClass.Archer)).Count()
           || warriorInput.TotalWarrior(WarriorClass.Mage) > dragons.SelectMany(x => x.Passengers.Where(x => x == WarriorClass.Mage)).Count()
           || warriorInput.TotalWarrior(WarriorClass.Healer) > dragons.SelectMany(x => x.Passengers.Where(x => x == WarriorClass.Healer)).Count();
}
