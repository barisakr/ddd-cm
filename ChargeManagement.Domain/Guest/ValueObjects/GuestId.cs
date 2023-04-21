using ChargeManagement.Domain.Common.Models;
using ChargeManagement.Domain.User.ValueObjects;

namespace ChargeManagement.Domain.Guest.ValueObjects
{
    public class GuestId : ValueObject
    {
        public string Value { get; }

        public GuestId(UserId userId)
        {
            Value = $"Guest_{userId.Value}";
        }

        public GuestId(string userId)
        {
            Value = userId;
        }

        internal static GuestId Create(UserId userId)
        {
            return new GuestId(userId);
        }

        public static GuestId Create(string userId)
        {
            return new GuestId(userId);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}