using BuberDinner.Domain.Dinner.Enums;
using ChargeManagement.Domain.Bill.ValueObjects;
using ChargeManagement.Domain.Common.Models;
using ChargeManagement.Domain.Dinner.ValueObjects;
using ChargeManagement.Domain.Guest.ValueObjects;

namespace ChargeManagement.Domain.Dinner.Entities
{
    public sealed class Reservation : Entity<ReservationId>
    {
        public DinnerId DinnerId { get; }
        public int GuestCount { get; }
        public GuestId GuestId { get; }
        public BillId? BillId { get; }
        public ReservationStatus Status { get; }
        public DateTime? ArrivalDateTime { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Reservation(
            DinnerId dinnerId,
            GuestId guestId,
            int guestCount,
            DateTime? arrivalDateTime,
            BillId billId,
            ReservationStatus status)
            : base(ReservationId.Create(dinnerId, guestId))
        {
            DinnerId = dinnerId;
            GuestId = guestId;
            GuestCount = guestCount;
            ArrivalDateTime = arrivalDateTime;
            BillId = billId;
            Status = status;
        }

        public static Reservation Create(
            DinnerId dinnerId,
            GuestId guestId,
            int guestCount,
            ReservationStatus status,
            BillId? billId = null,
            DateTime? arrivalDateTime = null)
        {
            // TODO: Enforce invariants
            return new Reservation(
                dinnerId,
                guestId,
                guestCount,
                arrivalDateTime,
                billId,
                status);
        }
    }
}