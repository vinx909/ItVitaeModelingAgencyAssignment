using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service.Infrastructure.Sql.Configurations
{
    public class EventBuilderConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Client).WithMany(c => c.Events)/*.IsRequired()*/;
            builder.HasOne(e => e.EventType).WithMany()/*.IsRequired()*/;
            builder.HasMany(e => e.Models).WithMany(m => m.Events);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Description).HasMaxLength(255);
            builder.Property(e => e.AddressNumber).HasMaxLength(5);
            builder.Property(e => e.Postalcode).HasMaxLength(8);

            builder.HasData(
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
        }
    }
}
