using ChargeManagement.Domain.Brand;
using ErrorOr;
using MediatR;

namespace ChargeManagement.Application.Common.Commands.CreateBrand
{
    public record CreateBrandCommand(
        string Name,
        string Description,
        List<BrandModelCommand> BrandModels) : IRequest<ErrorOr<Brand>>;

    public record BrandModelCommand(
        string Name,
        string Description);
}