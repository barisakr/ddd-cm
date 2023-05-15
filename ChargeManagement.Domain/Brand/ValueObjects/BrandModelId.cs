 using ChargeManagement.Domain.Common.Models;
 using ChargeManagement.Domain.Menu.ValueObjects;

 namespace ChargeManagement.Domain.Brand.ValueObjects
{
    public sealed class BrandModelId : ValueObject
    {
        public BrandModelId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; set; }

        public static BrandModelId CreateUnique()
        {
            // TODO: enforce invariants
            return new BrandModelId(Guid.NewGuid());
        }

        public static BrandModelId Create(Guid value)
        {
            // TODO: enforce invariants
            return new BrandModelId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}