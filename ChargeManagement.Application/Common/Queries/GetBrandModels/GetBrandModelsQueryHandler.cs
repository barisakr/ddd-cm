using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargeManagement.Application.Common.Interfaces.Authentication;
using ChargeManagement.Application.Common.Interfaces.Persistence;
using ChargeManagement.Application.Common.Queries.GetBrands;
using ChargeManagement.Contracts.Common.GetBrandModels;
using ChargeManagement.Contracts.Common.GetBrands;
using MediatR;
using ErrorOr;
namespace ChargeManagement.Application.Common.Queries.GetBrandModels
{
    public class GetBrandModelsQueryHandler : IRequestHandler<GetBrandModelsQuery, ErrorOr<GetBrandModelsResponse>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IBrandModelRepository _brandModelRepository;

        public GetBrandModelsQueryHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IBrandModelRepository brandModelRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _brandModelRepository = brandModelRepository;
        }

        public async Task<ErrorOr<GetBrandModelsResponse>> Handle(GetBrandModelsQuery query, CancellationToken cancellationToken)
        {
            var result = await _brandModelRepository.GetBrandModelsAsync(query.brandId);
             
            return new GetBrandModelsResponse(
               data: result
            );

        }
    }
}
