 
using ChargeManagement.Application.Authentication.Common;
using ChargeManagement.Application.Common.Commands.CreateBrand; 
using ChargeManagement.Application.Menus.Commands.CreateMenu;
using ChargeManagement.Contracts.Authentication;
using ChargeManagement.Contracts.Common.CreateBrand;
using ChargeManagement.Contracts.Menus;
using ChargeManagement.Domain.Brand;
using ChargeManagement.Domain.Menu;
using ChargeManagement.Domain.Menu.Entities;
using Mapster;

using BrandModel = ChargeManagement.Domain.Brand.Entities.BrandModel;
using MenuSection = ChargeManagement.Contracts.Menus.MenuSection;

namespace ChargeManagement.Api.Common.Mapping
{
    public class BrandMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateBrandRequest, CreateBrandCommand>();

            config.NewConfig<Brand, CreateBrandResponse>()
                .Map(dest => dest.Id, s => s.Id.Value)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description);

            config.NewConfig<BrandModel, BrandModelResponse>()
                .Map(dest => dest.Id, s => s.Id.Value);
        }
    }
}