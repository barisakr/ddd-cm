using ChargeManagement.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace ChargeManagement.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;