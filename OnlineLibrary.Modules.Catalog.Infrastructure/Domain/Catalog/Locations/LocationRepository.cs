using Microsoft.EntityFrameworkCore;
using OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Infrastructure.Domain.Catalog.Locations
{
    public class LocationRepository : ILocationRepository
    {
        private readonly CatalogContext _catalogContext;

        public LocationRepository(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task AddAsync(Location location)
        {
            await _catalogContext.Locations.AddAsync(location);
        }

        public async Task<List<Location>> GetAllLocations()
        {
            return await _catalogContext.Locations.ToListAsync();
        }

        public async Task<Location?> GetByIdAsync(Guid locationId)
        {
            return await _catalogContext.Locations.FirstOrDefaultAsync(x => x.LocationId == locationId);
        }

        public async Task<Location?> GetByName(string name)
        {
            return await _catalogContext.Locations.Where(x => x.LocationName == name).FirstOrDefaultAsync();
        }

        public async  Task<List<Location>> GetByOwnerId(Guid ownerId)
        {
            return await _catalogContext.Locations.Where(x => x.OwnerId == ownerId).ToListAsync();
        }

        public void UpdateLocation(Location location)
        {
            _catalogContext.Locations.Update(location);
        }
    }
}
