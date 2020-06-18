using Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IPhoneValidation, PhoneValidationService>();
            return services;
        }
    }
}
