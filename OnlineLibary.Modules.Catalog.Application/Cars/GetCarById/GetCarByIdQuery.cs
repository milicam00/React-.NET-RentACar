using OnlineLibary.Modules.Catalog.Application.Configuration.Queries;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscription;

namespace OnlineRentCar.Modules.Catalog.Application.Cars.GetCarById
{
    public class GetCarByIdQuery : QueryBase<CarDto>
    {
        public GetCarByIdQuery(Guid carId)
        {
            CarId = carId;
        }
        public Guid CarId { get; set; }
    }
}
