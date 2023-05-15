using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargeManagement.Domain.Brand.Entities;
using ChargeManagement.Domain.Brand.ValueObjects;
using ChargeManagement.Domain.Common.Models;

namespace ChargeManagement.Domain.Brand
{
    public sealed class Brand : AggregateRoot<BrandId>
    {
        private readonly List<BrandModel> _brandModels = new();

        public string Name { get; set; } 
        public string Description { get; set; }

        public IReadOnlyList<BrandModel> BrandModels => _brandModels.AsReadOnly();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }


        private Brand(
            BrandId brandId, 
            string name,
            string description,
            List<BrandModel> brandModels
            )
            : base(brandId)
        {
            Name = name;
            Description = description;
            _brandModels = brandModels;

        }

        public static Brand Create(
            string name,
            string description,
            List<BrandModel>? brandModels = null
            )
        { 
            return new Brand(
                BrandId.CreateUnique(), 
                name,
                description,
                brandModels ?? new()
                );
        }
        public Brand()
        {
        }
    }
}
