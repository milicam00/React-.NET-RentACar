using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineRentCar.Modules.Catalog.Domain.RentalCars.RentalCarSubscription;

namespace OnlineRentCar.Modules.Catalog.Infrastructure.Domain.Catalog.RentalCars
{
    internal class RentalCarConfiguration : IEntityTypeConfiguration<RentalCar>
    {
        public void Configure(EntityTypeBuilder<RentalCar> builder)
        {
            builder.HasKey(x => x.RentalCarId);

            builder.HasOne(rb => rb.Car)
                .WithMany(b => b.RentalCars)
                .HasForeignKey(rb => rb.CarId);

            builder.HasOne(rb => rb.Rental)
               .WithMany(r => r.RentalCars)
               .HasForeignKey(rb => rb.RentalId);
        }
    }
}
