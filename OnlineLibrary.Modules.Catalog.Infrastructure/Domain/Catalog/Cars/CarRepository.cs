using Microsoft.EntityFrameworkCore;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Infrastructure.Domain.Catalog.Cars
{
    public class CarRepository : ICarRepository
    {
        private readonly CatalogContext _catalogContext;

        public CarRepository(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task AddAsync(Car car)
        {
            await _catalogContext.Cars.AddAsync(car);
        }

        public void DeleteCar(Car car)
        {
             _catalogContext.Cars.Remove(car);
        }

        public async Task<PaginationResult<Car>> Get(PaginationFilter filter)
        {
            if (filter.PageNumber <= 0 || filter.PageSize <= 0)
            {
                throw new ArgumentException("Invalid page number or page size.");
            }

            var totalRecords = await _catalogContext.Cars.CountAsync();

            var pagedData = await _catalogContext.Cars
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();

            PaginationResult<Car> result = new PaginationResult<Car>(filter.PageNumber, filter.PageSize, totalRecords, pagedData);

            return result;
        }

        public async Task<List<Car>> GetAllCars()
        {
            return await _catalogContext.Cars.ToListAsync();
        }

        public async Task<Car?> GetByIdAsync(Guid carId)
        {
            return await _catalogContext.Cars.FirstOrDefaultAsync(x => x.CarId == carId);
        }

      

        public void UpdateCar(Car car)
        {
            _catalogContext.Cars.Update(car);
        }
    }
}
