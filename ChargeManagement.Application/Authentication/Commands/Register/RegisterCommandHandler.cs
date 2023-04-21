using ChargeManagement.Application.Common.Interfaces.Authentication;
using ChargeManagement.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using ChargeManagement.Application.Authentication.Common;
using ChargeManagement.Domain.User;
using ChargeManagement.Domain.Common;
using ChargeManagement.Domain.Common.Errors;

namespace ChargeManagement.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler :
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

        // 1. Validate the user doesn't exist
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        // 2. Create user (generate unique ID) & Persist to DB
        var user = User.Create(command.FirstName, command.LastName, command.Email, command.Password);

        _userRepository.Add(user);

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
        }
    }
}