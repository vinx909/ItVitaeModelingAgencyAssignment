using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service.Infrastructure.Sql.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder SetEntityAttributes(this ModelBuilder modelBuilder)
        {
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
                e.HasOne(e => e.Client).WithMany(c => c.Events)/*.IsRequired()*/;
                e.HasOne(e => e.EventType).WithMany()/*.IsRequired()*/;
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
                i.HasOne(i => i.Model).WithMany(m => m.images)/*.IsRequired()*/;
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
            return modelBuilder;
        }

        public static ModelBuilder SeedClientData(this ModelBuilder modelBuilder)
        {
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
            return modelBuilder;
        }

        public static ModelBuilder SeedEventTypeData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventType>().HasData(
                new EventType
                {
                    Id = 1,
                    Name = "Beurs",
                    Description = "Evenement waarbij nieuwe producten worden gepresenteerd"
                },
                new EventType
                {
                    Id = 2,
                    Name = "Conventie",
                    Description = "Evenement waarbij entertainment rondom een bepaald onderwerp centraal staat"
                }
            );
            return modelBuilder;
        }

        public static ModelBuilder SeedEventData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Name = "Auto show",
                    AddressNumber = 12,
                    Description = "Show met auto's",
                    Duration = 3,
                    Postalcode = "3568 GG",
                    StartTime = DateTime.Now.AddDays(2) 
                },
                new Event
                {
                    Id = 2,
                    Name = "Anime con",
                    AddressNumber = 3,
                    Description = "Evenement rondom anime",
                    Duration = 3,
                    Postalcode = "4201 BR",
                    StartTime = DateTime.Now.AddDays(5)
                },
                new Event
                {
                    Id = 3,
                    Name = "Verzamelbeurs",
                    AddressNumber = 7,
                    Description = "Show met verzamel items",
                    Duration = 1,
                    Postalcode = "6734 TY",
                    StartTime = DateTime.Now.AddDays(7)
                }
            );
            return modelBuilder;
        }

        public static ModelBuilder SeedModelData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>().HasData(
                new Model
                {
                    Id = 1,
                    Age = 22,
                    AddressNumber = 12,
                    City = "Amsterdam",
                    ClothingSize = 38,
                    Name = "Lotte",
                    EMailAdress = "LotteKraamer@gmail.com",
                    EyeColor = "Blauw-groen",
                    HairColor = "Blond",
                    Length = 178,
                    Postalcode = "4623 GH",
                    TelephoneNumber = 0612345678,
                    Description = "Veel energie"
                },
                new Model
                {
                    Id = 2,
                    Age = 24,
                    AddressNumber = 8,
                    City = "Groningen",
                    ClothingSize = 40,
                    Name = "Anne",
                    EMailAdress = "AnneVanBeekeren@gmail.com",
                    EyeColor = "Blauw",
                    HairColor = "Licht-Bruin",
                    Length = 176,
                    Postalcode = "7856 TH",
                    TelephoneNumber = 0612341234,
                    Description = "Rustig"
                },
                new Model
                {
                    Id = 3,
                    Age = 21,
                    AddressNumber = 3,
                    City = "Amersfoort",
                    ClothingSize = 36,
                    Name = "Emma",
                    EMailAdress = "EmmaVanZuiden@gmail.com",
                    EyeColor = "Bruin",
                    HairColor = "Zwart",
                    Length = 174,
                    Postalcode = "5674 UH",
                    TelephoneNumber = 0612344567,
                    Description = "Ingetogen"
                }
            );
            return modelBuilder;
        }
    }
}
