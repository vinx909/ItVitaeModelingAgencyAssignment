using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModelingAgency.Data.Service.Infrastructure.Sql.Configurations;
using ModelingAgency.Data.Service.Repositories;
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

            //Proberen services toe te voegen ERROR IDENTITY
            //services.AddTransient<RolesConfiguration>();
            //services.AddTransient<UserManager<IdentityUser>>();
            //services.AddTransient<RoleManager<IdentityRole>>();
            //services.AddTransient<IRoleStore<IdentityRole>>();

            return services;
        }
    }
}
