using OnlineLibary.Modules.Catalog.Application.Configuration.Commands;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscriptions;
using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Application.Locations.CreateLocation
{
    public class CreateLocationCommandHandler : ICommandHandler<CreateLocationCommand, Result>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IOwnerRepository _ownerRepository;

        public CreateLocationCommandHandler(ILocationRepository locationRepository, IOwnerRepository ownerRepository)
        {
            _locationRepository = locationRepository;
            _ownerRepository = ownerRepository;
        }


        public async Task<Result> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {

            Location locationWithSameName = await _locationRepository.GetByName(request.LocationName);
            Owner owner = await _ownerRepository.GetByUsername(request.OwnerUsername);
            if (locationWithSameName != null)
            {
                return Result.Failure("Location with same name already exist.");
            }
            var location = Location.CreateLocation(request.LocationName, request.ContactNumber, request.Email, owner.OwnerId, request.Address);
            await _locationRepository.AddAsync(location);
            return Result.Success("Location is successfully created!");

        }
    }
}
