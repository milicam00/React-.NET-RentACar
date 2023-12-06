using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineRentCar.Modules.Catalog.Domain.Rentals.RentalSubscription;

namespace OnlineRentCar.Modules.Catalog.Infrastructure.Domain.Catalog.Rentals
{
    public class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.HasKey(x => x.RentalId);


            builder.HasOne(r => r.Client)
                .WithMany()
                .HasForeignKey(r => r.ClientId);

        }
    }
}
