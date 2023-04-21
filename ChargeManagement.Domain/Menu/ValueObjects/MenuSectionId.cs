using ChargeManagement.Domain.Common.Models;

namespace ChargeManagement.Domain.Menu.ValueObjects
{
    public sealed class MenuSectionId : ValueObject
    {
     public MenuSectionId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; set; }

    public static MenuSectionId CreateUnique()
    {
        // TODO: enforce invariants
        return new MenuSectionId(Guid.NewGuid());
    }

    public static MenuSectionId Create(Guid value)
    {
        // TODO: enforce invariants
        return new MenuSectionId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    }
}