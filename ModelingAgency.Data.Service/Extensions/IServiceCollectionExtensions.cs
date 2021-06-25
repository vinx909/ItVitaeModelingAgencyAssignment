using Microsoft.Extensions.DependencyInjection;
using ModelingAgency.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services)
        {
            services.AddScoped<IClientData, ClientData>();
            services.AddScoped<IEventData, EventData>();
            services.AddScoped<IModelData, ModelData>();
            services.AddScoped<ITypeEventData, TypeEventData>();
            return services;
        }
    }
}
