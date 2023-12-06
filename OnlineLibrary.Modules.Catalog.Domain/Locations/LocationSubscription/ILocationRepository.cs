using OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscription
{
    public interface ILocationRepository
    {
        Task AddAsync(Location location);
        Task<Location?> GetByIdAsync(Guid locationId);
        Task<List<Location>> GetByOwnerId(Guid ownerId);
        void UpdateLocation(Location location);
        Task<Location> GetByName(string name);
        Task<List<Location>> GetAllLocations();
    }
}
