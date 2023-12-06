using OnlineLibary.Modules.Catalog.Application.Configuration.Commands;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Application.Clients.ReverseRegisterClient
{
    public class ReverseRegisterClientCommandHandler : ICommandHandler<ReverseRegisterUserCommand, Result>
    {
        private readonly IClientRepository _clientRepository;
        public ReverseRegisterClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<Result> Handle(ReverseRegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Client client = await _clientRepository.GetByUsername(request.Username);
                if (client == null)
                {
                    return Result.Failure("User does not exist.");
                }
                _clientRepository.Delete(client);
                return Result.Success("Deleted user");
            }
            catch (Exception ex)
            {
                return Result.Failure("Error message: " + ex.Message);
            }
        }
    }
}
