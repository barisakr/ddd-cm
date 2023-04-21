using ChargeManagement.Domain.Common.Models;
using ChargeManagement.Domain.Dinner.ValueObjects;
using ChargeManagement.Domain.Host.ValueObjects;

namespace ChargeManagement.Domain.Guest.ValueObjects
{
    public sealed class GuestRatingId : ValueObject
    {
        public string Value { get; }

        private GuestRatingId(string value)
        {
            Value = value;
        }

        private GuestRatingId(DinnerId dinnerId, HostId hostId)
        {
            Value = $"Rating_{dinnerId.Value}_{hostId.Value}";
        }

        public static GuestRatingId Create(DinnerId dinnerId, HostId hostId)
        {
            return new GuestRatingId(dinnerId, hostId);
        }

        public static GuestRatingId Create(string value)
        {
            return new GuestRatingId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}