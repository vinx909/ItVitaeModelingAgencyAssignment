using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ModelingAgency.Data.Service.Infrastructure.Sql
{
    public class ModelingAgencyContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().ToTable(nameof(Clients));
            modelBuilder.Entity<Client>(c =>
            {
                c.HasKey(c => c.Id);
                c.HasOne(c => c.EditOf).WithMany();
                c.HasMany(c => c.Events).WithOne(e => e.Client);
            });
            modelBuilder.Entity<Event>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasOne(e => e.Client).WithMany(c => c.Events).IsRequired();
                e.HasOne(e => e.EventType).WithMany().IsRequired();
                e.HasMany(e => e.Models).WithMany(m => m.Events);
                e.Property(e => e.Description).HasMaxLength(255);
            });
            modelBuilder.Entity<EventType>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Name).IsRequired().HasMaxLength(50);
                e.Property(e => e.Description).HasMaxLength(255);
            });
            modelBuilder.Entity<Image>(i =>
            {
                i.HasKey(i => i.Id);
                i.HasOne(i => i.Model).WithMany(m => m.Images).IsRequired();
            });
            modelBuilder.Entity<Model>().ToTable(nameof(Models));
            modelBuilder.Entity<Model>(m =>
            {
                m.HasKey(m => m.Id);
                m.HasMany(m => m.Images).WithOne(i => i.Model);
                m.Property(m => m.EMailAdress).IsRequired().HasMaxLength(50);
                m.Property(m => m.Description).HasMaxLength(255);
                m.HasMany(m => m.Events).WithMany(e => e.Models);
            });
            modelBuilder.Entity<Person>().ToTable(nameof(People));
            modelBuilder.Entity<Person>(p =>
            {
                p.HasKey(p => p.Id);
                p.HasOne(p => p.Role).WithMany();
            });
            modelBuilder.Entity<Role>(r =>
           {
               //r.HasKey(r=>r.)
           });
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
