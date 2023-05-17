using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using ChargeManagement.Domain.Brand.ValueObjects;
using ChargeManagement.Domain.Common.Models;

namespace ChargeManagement.Domain.Brand
{
    public sealed class BrandModel : AggregateRoot<BrandModelId>
    {
        public BrandId BrandId { get; }
        public string Name { get; set; } 
        public string Description { get; set; }  

        private BrandModel(
            BrandId brandId,
            BrandModelId brandModelId, 
            string name,
            string description
            )
            : base(brandModelId)
        {
            BrandId = brandId;
            Name = name;
            Description = description; 
        }

        public static BrandModel Create(
            BrandId brandId,
            string name,
            string description
            )
        { 
            return new BrandModel(
                brandId, 
                BrandModelId.CreateUnique(), 
                name,
                description
                );
        }
        public BrandModel()
        {
        }
    }
}
