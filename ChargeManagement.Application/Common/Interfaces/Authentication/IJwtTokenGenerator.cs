using ChargeManagement.Domain.User;

namespace ChargeManagement.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}