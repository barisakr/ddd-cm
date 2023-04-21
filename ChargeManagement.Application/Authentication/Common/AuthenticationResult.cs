using ChargeManagement.Domain.User;

namespace ChargeManagement.Application.Authentication.Common
{
    public record AuthenticationResult(User User, string Token);
}