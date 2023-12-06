using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscription
{
    public interface ICarRepository
    {
        Task AddAsync(Car car);
        void UpdateCar(Car car);
        Task<Car> GetByIdAsync(Guid carId);
        Task<PaginationResult<Car>> Get(PaginationFilter filter);
        void DeleteCar(Car car);
        Task<List<Car>> GetAllCars();
     
    }
}
