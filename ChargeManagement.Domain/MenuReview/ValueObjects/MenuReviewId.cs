using ChargeManagement.Domain.Common.Models;
using ChargeManagement.Domain.Dinner.ValueObjects;
using ChargeManagement.Domain.Guest.ValueObjects;
using ChargeManagement.Domain.Menu.ValueObjects;

namespace ChargeManagement.Domain.MenuReview.ValueObjects
{
    public sealed class MenuReviewId : ValueObject
    {
        public string Value { get; }

        private MenuReviewId(MenuId menuId, DinnerId dinnerId, GuestId guestId)
        {
            Value = $"MenuReview_{menuId.Value}_{dinnerId.Value}_{guestId.Value}";
        }

        private MenuReviewId(string value)
        {
            Value = value;
        }

        public static MenuReviewId Create(MenuId menuId, DinnerId dinnerId, GuestId guestId)
        {
            // TODO: enforce invariants
            return new MenuReviewId(menuId, dinnerId, guestId);
        }

        public static MenuReviewId Create(string value)
        {
            // TODO: enforce invariants
            return new MenuReviewId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}