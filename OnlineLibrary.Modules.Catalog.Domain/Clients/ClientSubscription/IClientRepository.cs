using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscription
{
    public interface IClientRepository
    {
        Task AddAsync(Client client);
        Task<Client> GetById(Guid clientId);
        void Update(Client client);
        Task<Client> GetByUsername(string username);
        void Delete(Client client);
        Task<List<Client>> GetAll();
    }
}
