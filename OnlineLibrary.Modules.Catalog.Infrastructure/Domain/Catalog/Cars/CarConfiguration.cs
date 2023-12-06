using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Infrastructure.Domain.Catalog.Cars
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.CarId);

            builder.Property(b => b.Model)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(b => b.Brand)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(b => b.Color)
                .HasMaxLength(75)
                .IsRequired();

            builder.HasOne(b => b.Location)
            .WithMany(l => l.Cars)
            .HasForeignKey(b => b.LocationId);

        }
    }
}
