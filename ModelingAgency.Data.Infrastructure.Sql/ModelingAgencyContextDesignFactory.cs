using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ModelingAgency.Data.Service.Infrastructure.Sql
{
    class ModelingAgencyContextDesignFactory : IDesignTimeDbContextFactory<ModelingAgencyContext>
    {
        public ModelingAgencyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ModelingAgencyContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ModelingAgencyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            return new ModelingAgencyContext(optionsBuilder.Options);
        }
    }
}
