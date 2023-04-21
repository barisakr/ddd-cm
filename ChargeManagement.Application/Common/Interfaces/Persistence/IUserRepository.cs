using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChargeManagement.Domain.User;

namespace ChargeManagement.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}