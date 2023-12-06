using OnlineLibary.Modules.Catalog.Application.Configuration.Queries;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscription;

namespace OnlineRentCar.Modules.Catalog.Application.Clients.GetClients
{
    public class GetClientsQueryHandler : IQueryHandler<GetClientsQuery, Result>
    {
        private readonly IClientRepository _clientRepository;
        public GetClientsQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Result> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            var clients = await _clientRepository.GetAll();
            return Result.Success(clients);
        }
    }
}
