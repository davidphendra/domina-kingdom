using TestA.Elazul.Domains;

namespace TestA.Elazul.Services;

public interface IElazulBatallionService
{
    IReadOnlyCollection<Dragon> Build(IReadOnlyCollection<WarriorClass> warriorInput);
}