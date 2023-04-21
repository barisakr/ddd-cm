
using System;
using ChargeManagement.Domain.Common.Models;
using ChargeManagement.Domain.User.ValueObjects;

namespace ChargeManagement.Domain.User
{
    public sealed class User : AggregateRoot<UserId>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set;}
        public string Password { get; set;} // TODO: Hash this

        public DateTime CreatedDateTime { get; set;}
        public DateTime UpdatedDateTime { get; set;}

        private User(string firstName, string lastName, string email, string password)
            : base(UserId.CreateUnique())
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            CreatedDateTime = DateTime.UtcNow;
            UpdatedDateTime = DateTime.UtcNow;
        }

        public static User Create(string firstName, string lastName, string email, string password)
        {
            // TODO: enforce invariants
            return new User(
                firstName,
                lastName,
                email,
                password);
        }
    }
}