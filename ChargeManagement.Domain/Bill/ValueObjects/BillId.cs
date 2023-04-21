using ChargeManagement.Domain.Common.Models;
using ChargeManagement.Domain.Dinner.ValueObjects;
using ChargeManagement.Domain.Guest.ValueObjects;

namespace ChargeManagement.Domain.Bill.ValueObjects;

public sealed class BillId : ValueObject
{
    public string Value { get; }

    private BillId(string value)
    {
        Value = value;
    }

    private BillId(DinnerId dinnerId, GuestId guestId)
    {
        Value = $"Bill_{dinnerId.Value}_{guestId.Value}";
    }

    public static BillId Create(DinnerId dinnerId, GuestId guestId)
    {
        return new BillId(dinnerId, guestId);
    }

    public static BillId Create(string value)
    {
        return new BillId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}