using ChargeManagement.Domain.Common.Models;

namespace ChargeManagement.Domain.User.ValueObjects
{
    public sealed class UserId : ValueObject
    {
        private UserId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        public static UserId CreateUnique()
        {
            return new UserId(Guid.NewGuid());
        }

        public static UserId Create(Guid userId)
        {
            return new UserId(userId);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}