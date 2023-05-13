using ChargeManagement.Domain.User;
using ChargeManagement.Domain.User.ValueObjects;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeManagement.Application.Users
{
    public class GetUserProfileByIdQuery : IRequest<ErrorOr<User>>
    {
        public Guid Id { get; }

        public GetUserProfileByIdQuery(Guid userId)
        {
            this.Id = userId;
        }
    } 
}
