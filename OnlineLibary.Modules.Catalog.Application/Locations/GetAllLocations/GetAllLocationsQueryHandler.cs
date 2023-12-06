using OnlineLibary.Modules.Catalog.Application.Configuration.Queries;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRentCar.Modules.Catalog.Application.Locations.GetAllLocations
{
    public class GetAllLocationsQueryHandler : IQueryHandler<GetAllLocationsQuery, Result>
    {
        private readonly ILocationRepository _locationRepository;
        public GetAllLocationsQueryHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public async Task<Result> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
        {
           var locations = await _locationRepository.GetAllLocations();
            return Result.Success(locations);
        }
    }
}
