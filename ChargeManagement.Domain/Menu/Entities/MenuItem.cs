using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChargeManagement.Domain.Common.Models;
using ChargeManagement.Domain.Menu.ValueObjects;

namespace ChargeManagement.Domain.Menu.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        public MenuItem(MenuItemId id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public static MenuItem Create(
            string name,
            string description)
        {
            return new(MenuItemId.CreateUnique(), name, description);
        }

        public MenuItem()
        {
        }
    }
}