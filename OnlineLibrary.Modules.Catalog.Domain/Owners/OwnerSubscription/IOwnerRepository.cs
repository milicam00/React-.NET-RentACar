using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscription
{
    public interface IOwnerRepository
    {
        Task AddAsync(Owner owner);
        void UpdateOwner(Owner owner);
        Task<Owner> GetById(Guid ownerId);
        Task<Owner> GetByUsername(string username);
        void Update(Owner owner);
        void Delete(Owner owner);
        Task<List<Owner>> GetAll();
    }
}
