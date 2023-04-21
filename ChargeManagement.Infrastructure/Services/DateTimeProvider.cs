using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChargeManagement.Application.Common.Interfaces.Services;

namespace ChargeManagement.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}