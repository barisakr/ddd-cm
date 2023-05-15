using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargeManagement.Domain.Brand.ValueObjects;
using ChargeManagement.Domain.Common.Models;


namespace ChargeManagement.Domain.Brand.Entities
{
    public sealed class BrandModel : Entity<BrandModelId>
    { 
        public string Name { get; set; }
        public string Description { get; set; } 

        private BrandModel(string name, string description, BrandModelId? id = null)
            : base(id ?? BrandModelId.CreateUnique())
        {
            Name = name;
            Description = description; 
        }

        public static BrandModel Create(
            string name,
            string description)
        {
            return new BrandModel(name, description);
        }

        public BrandModel()
        {
        }
    }
}