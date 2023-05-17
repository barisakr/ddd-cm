using ChargeManagement.Contracts.Common.GetBrandModels;
using ChargeManagement.Domain.Brand.ValueObjects;
using ErrorOr;
using MediatR;

namespace ChargeManagement.Application.Common.Queries.GetBrandModels
{

    public record GetBrandModelsQuery(BrandId brandId) : IRequest<ErrorOr<GetBrandModelsResponse>>;
}
