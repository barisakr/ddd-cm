using ChargeManagement.Application.Users;
using ChargeManagement.Contracts.Users;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChargeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediatr;

        public UsersController(IMapper mapper, IMediator mediatr)
        {
            _mapper = mapper;
            _mediatr = mediatr;
        }
        [HttpGet]
        public async Task<IActionResult> GetUserProfileById([FromBody] GetUserProfileRequest user)
        {
            var userResult = await _mediatr.Send(new GetUserProfileByIdQuery(user.Id));

            return userResult.Match(
               user => Ok(_mapper.Map<GetUserProfileResponse>(user)),
               errors => Problem(errors));
            
        }
    }
}