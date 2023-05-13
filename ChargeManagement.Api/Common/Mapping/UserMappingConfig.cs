using ChargeManagement.Application.Users;
using ChargeManagement.Domain.User;
using Mapster;

namespace ChargeManagement.Api.Common.Mapping
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {


            config.NewConfig<User, UserResponse>()
                .Map(dest => dest.Id, s => s.Id.Value)
                .Map(dest => dest.FirstName, s => s.FirstName); 
        }
    }
}
