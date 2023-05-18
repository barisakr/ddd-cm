using System.Reflection;
using ChargeManagement.Api.Common.Errors;
using ChargeManagement.Api.Common.Mapping;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ChargeManagement.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, ChargeManagementProblemDetailsFactory>();
            //services.AddAutoMapper(typeof(Program));
            services.AddMappings();
            return services;
        }
    }
}