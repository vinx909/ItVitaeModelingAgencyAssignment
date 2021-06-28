using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service.Infrastructure.Sql.Configurations
{
    public class EventTypeBuilderConfiguration : IEntityTypeConfiguration<EventType>
    {
        public void Configure(EntityTypeBuilder<EventType> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Description).HasMaxLength(255);

            builder.HasData(
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
        }
    }
}
