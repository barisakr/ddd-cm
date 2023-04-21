using ChargeManagement.Domain.Common.Models;
using ChargeManagement.Domain.Common.ValueObjects;
using ChargeManagement.Domain.Dinner.ValueObjects;
using ChargeManagement.Domain.Guest.ValueObjects;
using ChargeManagement.Domain.Host.ValueObjects;
using ErrorOr;

namespace ChargeManagement.Domain.Guest.Entities
{
    public sealed class GuestRating : Entity<GuestRatingId>
    {
        public HostId HostId { get; }
        public DinnerId DinnerId { get; }
        public Rating Rating { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private GuestRating(DinnerId dinnerId, HostId hostId, Rating rating)
            : base(GuestRatingId.Create(dinnerId, hostId))
        {
            DinnerId = dinnerId;
            HostId = hostId;
            Rating = rating;
        }

        public static ErrorOr<GuestRating> Create(DinnerId dinnerId, HostId hostId, int rating)
        {
            var ratingValueObject = Rating.Create(rating);

            return new GuestRating(dinnerId, hostId, ratingValueObject);
        }
    }
}