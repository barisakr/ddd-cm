using ChargeManagement.Domain.Common.Models;
using ChargeManagement.Domain.Common.ValueObjects;
using ChargeManagement.Domain.Dinner.ValueObjects;
using ChargeManagement.Domain.Guest.ValueObjects;
using ChargeManagement.Domain.Host.ValueObjects;
using ChargeManagement.Domain.Menu.ValueObjects;
using ChargeManagement.Domain.MenuReview.ValueObjects;

namespace ChargeManagement.Domain.MenuReview
{
    public sealed class MenuReview : AggregateRoot<MenuReviewId>
    {
        public Rating Rating { get; }
        public string Comment { get; }
        public HostId HostId { get; }
        public MenuId MenuId { get; }
        public GuestId GuestId { get; }
        public DinnerId DinnerId { get; }

        private MenuReview(
            MenuReviewId menuReviewId,
            Rating rating,
            string comment,
            HostId hostId,
            MenuId menuId,
            GuestId guestId,
            DinnerId dinnerId)
            : base(menuReviewId)
        {
            Rating = rating;
            Comment = comment;
            HostId = hostId;
            MenuId = menuId;
            GuestId = guestId;
            DinnerId = dinnerId;
        }

        public static MenuReview Create(
            int rating,
            string comment,
            HostId hostId,
            MenuId menuId,
            GuestId guestId,
            DinnerId dinnerId,
            MenuReviewId menuReviewId = null)
        {
            // TODO: enforce invariants
            var ratingValueObject = Rating.Create(rating);

            return new MenuReview(
                menuReviewId ?? MenuReviewId.Create(menuId, dinnerId, guestId),
                ratingValueObject,
                comment,
                hostId,
                menuId,
                guestId,
                dinnerId);
        }
    }
}