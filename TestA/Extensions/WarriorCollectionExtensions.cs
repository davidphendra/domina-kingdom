using TestA.Elazul.Domains;

namespace TestA.Elazul.Extensions;

public static class WarriorCollectionExtensions
{
    public static int TotalWarrior(this IReadOnlyCollection<WarriorClass> warriorClasses, WarriorClass warriorClass)
    {
        return warriorClasses?.Count(x => x == warriorClass) ?? 0;
    }
}