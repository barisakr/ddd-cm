using ChargeManagement.Application.Authentication.Commands.Register;
using ChargeManagement.Application.Authentication.Common;
using ChargeManagement.Application.Authentication.Queries.Login;
using ChargeManagement.Contracts.Authentication;
using Mapster;

namespace ChargeManagement.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
      public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Id, src => src.User.Id.Value)
            .Map(dest => dest, src => src.User);
    }
    }
}