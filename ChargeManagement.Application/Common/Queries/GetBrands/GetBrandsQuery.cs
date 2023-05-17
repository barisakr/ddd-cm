using ErrorOr;
using MediatR;


namespace ChargeManagement.Application.Common.Queries.GetBrands
{
    public record GetBrandsQuery() : IRequest<ErrorOr<GetBrandsResponse>>;
}