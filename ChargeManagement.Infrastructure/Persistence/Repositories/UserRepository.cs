using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChargeManagement.Application.Common.Interfaces.Persistence;
using ChargeManagement.Domain.User;

namespace ChargeManagement.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ChargeManagementDbContext _context;

        public UserRepository(ChargeManagementDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }
    }
}