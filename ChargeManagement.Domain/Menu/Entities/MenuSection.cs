using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChargeManagement.Domain.Common.Models;
using ChargeManagement.Domain.Menu.ValueObjects;

namespace ChargeManagement.Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items;
        public string Name { get; set; }
        public string Description { get; set; }

        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        private MenuSection(string name, string description, List<MenuItem> items, MenuSectionId? id = null)
            : base(id ?? MenuSectionId.CreateUnique())
        {
            Name = name;
            Description = description;
            _items = items;
        }

        public static MenuSection Create(
            string name,
            string description,
            List<MenuItem>? items = null)
        {
            return new MenuSection(name, description, items ?? new());
        }

        public MenuSection()
        {
        }
    }
}