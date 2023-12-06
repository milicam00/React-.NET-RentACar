using OnlineLibary.Modules.Catalog.Application.Configuration.Commands;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscriptions;
using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Application.Owners.ChangeOwnerUsernameCommand
{
    public class ChangeOwnerUsernameCommandHandler : ICommandHandler<ChangeOwnerUsernameCommand, Result>
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IClientRepository _clientRepository;

        public ChangeOwnerUsernameCommandHandler(IOwnerRepository ownerRepository, IClientRepository clientRepository)
        {
            _ownerRepository = ownerRepository;
            _clientRepository = clientRepository;
        }
        public async Task<Result> Handle(ChangeOwnerUsernameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Owner owner = await _ownerRepository.GetByUsername(request.OldUsername);
                Owner existingOwnerWithNewUsername = await _ownerRepository.GetByUsername(request.NewUsername);
                Client existingClientWithNewUsername = await _clientRepository.GetByUsername(request.NewUsername);
                if (owner == null)
                {
                    return Result.Failure("Owner does  not exist.");
                }

                if (existingOwnerWithNewUsername != null || existingClientWithNewUsername != null)
                {
                    return Result.Failure("Owner with this username already exist.");
                }
                owner.ChangeUsername(request.NewUsername);
                _ownerRepository.Update(owner);

                return Result.Success("Successfully changed username.");
            }
            catch (Exception ex)
            {
                return Result.Failure("An error occurred while processing the request.Error: " + ex.Message);
            }

        }
    }
    }
