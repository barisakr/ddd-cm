using ChargeManagement.Application.Common.Interfaces.Authentication;
using ChargeManagement.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using ChargeManagement.Domain.Common.Errors;
using ChargeManagement.Application.Authentication.Common;
using ChargeManagement.Domain.User;

namespace ChargeManagement.Application.Authentication.Queries.Login
{
    public class LoginCommandHandler :
        IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginCommandHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            // 1. Validate the user exists
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // 2. Validate the password is correct
            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // 3. Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);
            await Task.CompletedTask;

            return new AuthenticationResult(
                user,
                token);
        }
    }
}