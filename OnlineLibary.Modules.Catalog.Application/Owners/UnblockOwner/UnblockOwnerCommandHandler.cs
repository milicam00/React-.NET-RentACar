using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineLibary.Modules.Catalog.Application.Configuration.Commands;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscriptions;
using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Application.Owners.UnblockOwner
{
    public class UnblockOwnerCommandHandler : ICommandHandler<UnblockOwnerCommand, Result>
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly ILocationRepository _locationRepository;
        public UnblockOwnerCommandHandler(IOwnerRepository ownerRepository, ILocationRepository locationRepository)
        {
            _ownerRepository = ownerRepository;
            _locationRepository = locationRepository;

        }
        public async Task<Result> Handle(UnblockOwnerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Owner owner = await _ownerRepository.GetByUsername(request.UserName);
                if (owner == null)
                {
                    return Result.Failure("User does not exist.");
                }
                if (!owner.IsBlocked)
                {
                    return Result.Failure("User is already unblocked.");
                }
                owner.Unblock();
                List<Location> locations = await _locationRepository.GetByOwnerId(owner.OwnerId);
                if (locations != null)
                {
                    foreach (Location location in locations)
                    {
                        location.ActivateLocation();
                        _locationRepository.UpdateLocation(location);
                    }
                }
                _ownerRepository.UpdateOwner(owner);
                return Result.Success("User is unblocked.");
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx)
                {
                    return Result.Failure("Database error: " + sqlEx.Message);
                }
                return Result.Failure("Database error: " + ex.Message);

            }
            catch (Exception ex)
            {
                return Result.Failure("Error message: " + ex.Message);
            }
        }
    }
}
