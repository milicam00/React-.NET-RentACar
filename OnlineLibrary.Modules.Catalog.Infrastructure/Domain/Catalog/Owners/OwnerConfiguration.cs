using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Infrastructure.Domain.Catalog.Owners
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.HasKey(x => x.OwnerId);

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.HasIndex(p => p.UserName)
                .IsUnique();

            builder.Property(n => n.FirstName)
               .HasMaxLength(75)
               .IsRequired();

            builder.Property(n => n.LastName)
                .HasMaxLength(75)
                .IsRequired();

            builder.HasMany(e => e.Locations)
                .WithOne(e => e.Owner)
                .HasForeignKey(e => e.OwnerId)
                .IsRequired();
        }
    }
}
