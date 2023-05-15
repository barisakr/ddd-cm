using ChargeManagement.Domain.Common.Models;

namespace ChargeManagement.Domain.Brand.ValueObjects
{

    public sealed class BrandId : ValueObject
    {
        public Guid Value { get; set; }

        private BrandId(Guid value)
        {
            Value = value;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static BrandId Create(Guid value)
        {
            return new BrandId(value);
        }

        public static BrandId CreateUnique()
        {
            return new BrandId(Guid.NewGuid());
        }
    }
}
