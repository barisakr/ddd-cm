using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using ChargeManagement.Domain.Brand.ValueObjects;
using ChargeManagement.Domain.Common.Models;

namespace ChargeManagement.Domain.Brand
{
    public sealed class Brand : AggregateRoot<BrandId>
    { 
        public string Name { get; set; } 
        public string Description { get; set; } 
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }


        private Brand(
            BrandId brandId, 
            string name,
            string description
            )
            : base(brandId)
        {
            Name = name;
            Description = description;

        }

        public static Brand Create(
            string name,
            string description
            )
        { 
            return new Brand(
                BrandId.CreateUnique(), 
                name,
                description
                );
        }
        public Brand()
        {
        }
    }
}
