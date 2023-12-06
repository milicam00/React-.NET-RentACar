using Microsoft.EntityFrameworkCore;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRentCar.Modules.Catalog.Infrastructure.Domain.Catalog.Clients
{
    public class ClientRepository : IClientRepository
    {
        private readonly CatalogContext _catalogContext;

        public ClientRepository(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }
        public async Task AddAsync(Client client)
        {
            await _catalogContext.AddAsync(client);
        }

        public void Delete(Client client)
        {
            _catalogContext.Remove(client);
        }

        public async Task<List<Client>> GetAll()
        {
            return await _catalogContext.Clients.ToListAsync();
        }

        public async Task<Client?> GetById(Guid clientId)
        {
            return await _catalogContext.Clients.FirstOrDefaultAsync(x => x.ClientId == clientId);
        }

        public async Task<Client?> GetByUsername(string username)
        {
            return await _catalogContext.Clients.FirstOrDefaultAsync(x => x.UserName == username);
        }

        public void Update(Client client)
        {
            _catalogContext.Clients.Update(client);
        }
    }
}
