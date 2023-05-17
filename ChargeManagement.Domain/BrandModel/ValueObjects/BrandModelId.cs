using ChargeManagement.Domain.Common.Models;

namespace ChargeManagement.Domain.Brand.ValueObjects
{

    public sealed class BrandModelId : ValueObject
    {
        public Guid Value { get; set; }

        private BrandModelId(Guid value)
        {
            Value = value;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static BrandModelId Create(Guid value)
        {
            return new BrandModelId(value);
        }

        public static BrandModelId CreateUnique()
        {
            return new BrandModelId(Guid.NewGuid());
        }
    }
}
