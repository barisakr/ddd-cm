using AutoMapper;
using ChargeManagement.Application.Authentication.Commands.Register;
using ChargeManagement.Application.Authentication.Common;
using ChargeManagement.Application.Authentication.Queries.Login;
using ChargeManagement.Contracts.Authentication;

namespace ChargeManagement.Api.Common.Mapping
{
    public class AuthenticationMappingProfile : Profile
    {
        public AuthenticationMappingProfile()
        {

            CreateMap<RegisterRequest, RegisterCommand>();
            CreateMap<LoginRequest, LoginQuery>();

            CreateMap<AuthenticationResult, AuthenticationResponse>()
                .ForMember(x => x.Id, opt => opt.MapFrom(s => s.User.Id.Value));


            /*
            config.NewConfig<RegisterRequest, RegisterCommand>();

            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Id, src => src.User.Id.Value)
                .Map(dest => dest, src => src.User);

            */
        }
    }
}
