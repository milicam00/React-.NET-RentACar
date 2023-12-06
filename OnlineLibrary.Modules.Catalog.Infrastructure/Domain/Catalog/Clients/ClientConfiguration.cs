using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Infrastructure.Domain.Catalog.Clients
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.ClientId);

            builder.Property(n => n.FirstName)
               .HasMaxLength(75)
               .IsRequired();

            builder.Property(n => n.LastName)
                .HasMaxLength(75)
                .IsRequired();

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.HasIndex(p => p.UserName)
                .IsUnique();
        }
    }
}
