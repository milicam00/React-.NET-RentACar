using OnlineLibary.Modules.Catalog.Application.Configuration.Commands;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Application.Locations.DeactivateLocation
{
    internal class DeactivateLocationCommandHandler : ICommandHandler<DeactivateLocationCommand, Result>
    {
        private readonly ILocationRepository _locationRepository;

        public DeactivateLocationCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public async Task<Result> Handle(DeactivateLocationCommand request, CancellationToken cancellationToken)
        {
            Location location = await _locationRepository.GetByIdAsync(request.LocationId);
            if(location==null)
            {
                return Result.Failure("This location does not exist");
            }
            location.EditActivate(request.IsActive);
            _locationRepository.UpdateLocation(location);
            return Result.Success("Successfully updated!");
        }
    }
}
