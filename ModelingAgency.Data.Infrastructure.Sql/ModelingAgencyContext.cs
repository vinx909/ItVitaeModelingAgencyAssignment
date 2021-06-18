﻿using System;
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

            //modelBuilder.SetEntityAttributes();

            modelBuilder.Entity<Client>(c =>
            {
                c.HasKey(c => c.Id);
                c.HasOne(c => c.EditOf).WithMany();
                c.HasMany(c => c.Events).WithOne(e => e.Client);
                c.Property(c => c.Name).HasMaxLength(255);
                c.Property(c => c.AddressNumber).HasMaxLength(5);
                c.Property(c => c.Postalcode).HasMaxLength(8);
                c.Property(c => c.City).HasMaxLength(255);

            });
            modelBuilder.Entity<Event>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasOne(e => e.Client).WithMany(c => c.Events).IsRequired();
                e.HasOne(e => e.EventType).WithMany().IsRequired();
                e.HasMany(e => e.Models).WithMany(m => m.Events);
                e.Property(e => e.Name).IsRequired().HasMaxLength(50);
                e.Property(e => e.Description).HasMaxLength(255);
                e.Property(e => e.AddressNumber).HasMaxLength(5);
                e.Property(e => e.Postalcode).HasMaxLength(8);
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
                i.HasOne(i => i.Model).WithMany(m => m.images).IsRequired();
            });
            modelBuilder.Entity<Model>(m =>
            {
                m.HasKey(m => m.Id);
                m.HasMany(m => m.images).WithOne(i => i.Model);
                m.Property(m => m.EMailAdress).IsRequired().HasMaxLength(50);
                m.Property(m => m.Description).HasMaxLength(255);
                m.HasMany(m => m.Events).WithMany(e => e.Models);
                m.Property(m => m.Name).HasMaxLength(255);
                m.Property(m => m.AddressNumber).HasMaxLength(5);
                m.Property(m => m.Postalcode).HasMaxLength(8);
                m.Property(m => m.City).HasMaxLength(255);
            });

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = 1,
                    Name = "Henk",
                    Postalcode = "1234 GH",
                    AddressNumber = 45,
                    BTWNumber = 12345678,
                    City = "Amsterdam",
                    KVKNumber = 345678912
                },
                new Client
                {
                    Id = 2,
                    Name = "Jaap",
                    Postalcode = "3456 ER",
                    AddressNumber = 15,
                    BTWNumber = 45678123,
                    City = "Rotterdam",
                    KVKNumber = 67891234
                },
                new Client
                {
                    Id = 3,
                    Name = "Andre",
                    Postalcode = "4567 YU",
                    AddressNumber = 69,
                    BTWNumber = 89123456,
                    City = "Groningen",
                    KVKNumber = 14235867
                }
            );
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Model> Models { get; set; }
    }
}
