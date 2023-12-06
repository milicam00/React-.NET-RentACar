using OnlineLibary.Modules.Catalog.Application.Configuration.Queries;
using OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscription;

namespace OnlineRentCar.Modules.Catalog.Application.Locations.GetLocationsQuery
{
    public class GetLocationQuery : QueryBase<List<LocationDto>>
    {
        public string OwnerUsername { get; set; }
        public GetLocationQuery(string ownerUsername) 
        {
            OwnerUsername = ownerUsername;
        }
    }
}
