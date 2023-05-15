using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeManagement.Contracts.Users
{
    public record GetUserProfileResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Email
        );
}
