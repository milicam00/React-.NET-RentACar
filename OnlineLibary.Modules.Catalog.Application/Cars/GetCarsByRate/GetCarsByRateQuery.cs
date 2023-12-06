using OnlineLibary.Modules.Catalog.Application.Configuration.Queries;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscription;

namespace OnlineRentCar.Modules.Catalog.Application.Cars.GetCarsByRate
{
    public class GetCarsByRateQuery : QueryBase<List<CarDto>>
    {
        public GetCarsByRateQuery(int rate, int pageNumber, int pageSize)
        {
            Rate = rate;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public int Rate { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
