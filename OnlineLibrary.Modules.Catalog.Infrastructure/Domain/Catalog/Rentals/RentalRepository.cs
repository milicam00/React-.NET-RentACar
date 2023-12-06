using Microsoft.EntityFrameworkCore;
using OnlineRentCar.Modules.Catalog.Domain.Rentals.RentalSubscription;

namespace OnlineRentCar.Modules.Catalog.Infrastructure.Domain.Catalog.Rentals
{
    public class RentalRepository : IRentalRepository
    {
        private readonly CatalogContext _catalogContext;

        public RentalRepository(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task AddAsync(Rental rental)
        {
            await _catalogContext.Rentals.AddAsync(rental);
        }

        public async Task<Rental?> GetByClientId(Guid clientId)
        {
            return await _catalogContext.Rentals.Where(x => x.ClientId == clientId).FirstOrDefaultAsync();
        }

        public async Task<Rental?> GetByIdAsync(Guid rentalId)
        {
            return await _catalogContext.Rentals.Where(x => x.RentalId == rentalId).FirstOrDefaultAsync();
        }

        public async Task<int> GetTotalRentalsForClient(Guid clientId)
        {
           return await _catalogContext.Rentals.Where(x=>x.ClientId==clientId).CountAsync();
        }
    }
}
