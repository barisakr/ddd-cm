using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargeManagement.Domain.Brand;

namespace ChargeManagement.Application.Common.Interfaces.Persistence
{
    public interface IBrandRepository
    {
        void Add(Brand brand);
    }
  
}
