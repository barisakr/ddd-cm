using ChargeManagement.Application.Authentication.Common;
using ChargeManagement.Application.Menus.Commands.CreateMenu;
using ChargeManagement.Contracts.Authentication;
using ChargeManagement.Contracts.Menus;
using ChargeManagement.Domain.Menu;
using Mapster;

using MenuSection = ChargeManagement.Domain.Menu.Entities.MenuSection;
using MenuItem = ChargeManagement.Domain.Menu.Entities.MenuItem;

namespace ChargeManagement.Api.Common.Mapping
{
    public class MenuMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateMenuRequest request, string HostId), CreateMenuCommand>()
                .Map(dest => dest.HostId, s => s.HostId)
                .Map(dest => dest, s => s.request);

            config.NewConfig<Menu, MenuResponse>()
                .Map(dest => dest.Id, s => s.Id.Value)
                .Map(dest => dest.AverageRating, src => src.AverageRating.Value)
                .Map(dest => dest.HostId, src => src.HostId.Value)
                .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value))
                .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(menuId => menuId.Value));

            config.NewConfig<MenuSection, MenuSectionResponse>()
                .Map(dest => dest.Id, s => s.Id.Value);
            config.NewConfig<MenuItem, MenuItemResponse>()
                .Map(dest => dest.Id, s => s.Id.Value);
        }
    }
}