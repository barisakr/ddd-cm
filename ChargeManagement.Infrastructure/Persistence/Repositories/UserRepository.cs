using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChargeManagement.Application.Common.Interfaces.Persistence;
using ChargeManagement.Domain.User;
using ChargeManagement.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;

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

        public async Task<User> GetUserById(Guid userId)
        {
            var res =   UserId.Create(userId);
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == res);
        }
    }
}