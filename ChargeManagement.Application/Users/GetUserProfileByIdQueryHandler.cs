using ChargeManagement.Application.Common.Interfaces.Persistence;
using ChargeManagement.Domain.User;
using ErrorOr;
using MediatR;

namespace ChargeManagement.Application.Users
{
    public class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileByIdQuery, ErrorOr<User>>
    {
        private readonly IUserRepository _userRepository;
        
        public GetUserProfileByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<User>> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        { 
            var user = await _userRepository.GetUserById(request.Id); 
            return user;
        }
    }
}
