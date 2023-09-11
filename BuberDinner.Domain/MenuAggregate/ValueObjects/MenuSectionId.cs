using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;
public class MenuSectionId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public static MenuSectionId CreateUnique() => new(Guid.NewGuid());
    public static MenuSectionId Create(Guid menuSectionId) => new(menuSectionId);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private MenuSectionId() { }
}