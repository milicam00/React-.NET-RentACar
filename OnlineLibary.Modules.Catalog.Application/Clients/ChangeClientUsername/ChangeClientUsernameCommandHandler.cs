using OnlineLibary.Modules.Catalog.Application.Configuration.Commands;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscriptions;
using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Application.Clients.ChangeClientUsername
{
    public class ChangeClientUsernameCommandHandler : ICommandHandler<ChangeClientUsernameCommand, Result>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IOwnerRepository _ownerRepository;

        public ChangeClientUsernameCommandHandler(IClientRepository clientRepository, IOwnerRepository ownerRepository)
        {
            _clientRepository = clientRepository;
            _ownerRepository = ownerRepository;
        }

        public async Task<Result> Handle(ChangeClientUsernameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Client client = await _clientRepository.GetByUsername(request.OldUsername);
                Client existingClientWithNewUsername = await _clientRepository.GetByUsername(request.NewUsername);
                Owner existingOwnerWithNewUsername = await _ownerRepository.GetByUsername(request.NewUsername);
                if (client == null)
                {
                    return Result.Failure("Client does  not exist.");
                }

                if (existingClientWithNewUsername != null || existingOwnerWithNewUsername != null)
                {
                    return Result.Failure("User with this username already exist.");
                }

                client.ChangeUsername(request.NewUsername);
                _clientRepository.Update(client);

                return Result.Success("Successfully changed username.");
            }
            catch (Exception ex)
            {
                return Result.Failure("An error occurred while processing the request.Error: " + ex.Message);
            }
        }
    }
}
