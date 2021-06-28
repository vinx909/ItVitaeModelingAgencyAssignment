using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service.Infrastructure.Sql.Configurations
{
    public class ModelBuilderConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasKey(m => m.Id);
            builder.HasMany(m => m.images).WithOne(i => i.Model);
            builder.Property(m => m.EMailAdress).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Description).HasMaxLength(255);
            builder.HasMany(m => m.Events).WithMany(e => e.Models);
            builder.Property(m => m.Name).HasMaxLength(255);
            builder.Property(m => m.AddressNumber).HasMaxLength(5);
            builder.Property(m => m.Postalcode).HasMaxLength(8);
            builder.Property(m => m.City).HasMaxLength(255);

            builder.HasData(
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
        }
    }
}
