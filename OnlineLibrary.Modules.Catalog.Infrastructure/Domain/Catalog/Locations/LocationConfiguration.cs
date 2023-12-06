using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Infrastructure.Domain.Catalog.Locations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(x => x.LocationId);

            builder.Property(n => n.LocationName)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasMany(e => e.Cars)
                .WithOne(e => e.Location)
                .HasForeignKey(e => e.LocationId)
                .IsRequired();

            builder.HasOne(b => b.Owner)
                .WithMany(l => l.Locations)
                .HasForeignKey(b => b.OwnerId);
        }
    }
}
