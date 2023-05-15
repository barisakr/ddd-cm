using ChargeManagement.Application.Common.Commands.CreateBrand; 
using ChargeManagement.Application.Users;
using ChargeManagement.Contracts.Common.CreateBrand;
using ChargeManagement.Contracts.Menus;
using ChargeManagement.Contracts.Users;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChargeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    public class CommonController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediatr;

        public CommonController(IMapper mapper, IMediator mediatr)
        {
            _mapper = mapper;
            _mediatr = mediatr;
        }

        [HttpPost]
        [Route("CreateBrand")]

        public async Task<IActionResult> GetUserProfileById([FromBody] CreateBrandRequest request)
        {
            {
                var command = _mapper.Map<CreateBrandCommand>((request));
                var createBrandResult = await _mediatr.Send(command);

                return createBrandResult.Match(
                    brand => Ok(_mapper.Map<CreateBrandResponse>(brand)),
                    errors => Problem(errors));

            }
        }
    }
}