using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ModelingAgency.Data.Service.Infrastructure.Sql.Extensions;

namespace ModelingAgency.Data.Service.Infrastructure.Sql
{
    public class ModelingAgencyContext : DbContext
    {
        public ModelingAgencyContext(DbContextOptions<ModelingAgencyContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.SetEntityAttributes();

            modelBuilder.SeedClientData();

            modelBuilder.SeedEventData();

            modelBuilder.SeedModelData();

            modelBuilder.SeedEventTypeData();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Model> Models { get; set; }
    }
}
