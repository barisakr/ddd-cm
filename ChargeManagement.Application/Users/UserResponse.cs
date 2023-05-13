namespace ChargeManagement.Application.Users
{
   
    public record UserResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Email
    );
}