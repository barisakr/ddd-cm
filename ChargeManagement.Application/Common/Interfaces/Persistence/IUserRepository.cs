using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChargeManagement.Domain.User;
using ChargeManagement.Domain.User.ValueObjects;

namespace ChargeManagement.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<User> GetUserById(Guid userId);
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}