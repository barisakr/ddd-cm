using ChargeManagement.Application.Common.Interfaces.Authentication;
using ChargeManagement.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using ChargeManagement.Domain.Common.Errors;
using ChargeManagement.Application.Authentication.Common;
using ChargeManagement.Application.Common;
using ChargeManagement.Contracts.Common.GetBrands;
using ChargeManagement.Domain.Brand;
using ChargeManagement.Domain.User;

namespace ChargeManagement.Application.Common.Queries.GetBrands
{
    public class GetBrandsHandler :
        IRequestHandler<GetBrandsQuery, ErrorOr<GetBrandsResponse>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IBrandRepository _brandRepository;

        public GetBrandsHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IBrandRepository brandRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _brandRepository = brandRepository;
        }

        public async Task<ErrorOr<GetBrandsResponse>> Handle(GetBrandsQuery query, CancellationToken cancellationToken)
        {
            var result =  await _brandRepository.GetBrandsAsync();
            return new GetBrandsResponse(
                result
            );

        }
    }
}