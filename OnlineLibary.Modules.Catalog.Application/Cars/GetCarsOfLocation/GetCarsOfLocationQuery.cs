using OnlineLibary.Modules.Catalog.Application.Configuration.Queries;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscription;

namespace OnlineRentCar.Modules.Catalog.Application.Cars.GetCarsOfLocation
{
    public class GetCarsOfLocationQuery : QueryBase<List<CarDto>>
    {
        public GetCarsOfLocationQuery(Guid locationId) 
        {
            LocationId = locationId;
        }
        public Guid LocationId { get; set; }
    }
}
