using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service.Infrastructure.Sql.Configurations
{
    public class ClientBuilderConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.EditOf).WithMany();
            builder.HasMany(c => c.Events).WithOne(e => e.Client);
            builder.Property(c => c.Name).HasMaxLength(255);
            builder.Property(c => c.AddressNumber).HasMaxLength(5);
            builder.Property(c => c.Postalcode).HasMaxLength(8);
            builder.Property(c => c.City).HasMaxLength(255);

            builder.HasData(
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
    }
}
