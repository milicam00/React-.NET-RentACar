using Microsoft.EntityFrameworkCore;
using OnlineRentCar.Modules.Catalog.Domain.RentalCars.RentalCarSubscription;

namespace OnlineRentCar.Modules.Catalog.Infrastructure.Domain.Catalog.RentalCars
{
    public class RentalCarRepository : IRentalCarRepository
    {
        private readonly CatalogContext _catalogContext;

        public RentalCarRepository(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async  Task AddAsync(RentalCar rentalCar)
        {
            await _catalogContext.RentalCars.AddAsync(rentalCar);
        }

        public async Task<RentalCar?> GetByCarId(Guid carId)
        {
            return await _catalogContext.RentalCars.Where(x => x.CarId == carId).FirstOrDefaultAsync();
        }

        public async Task<RentalCar?> GetByIdAsync(Guid rentalCarId)
        {
            return await _catalogContext.RentalCars.FirstOrDefaultAsync(x => x.RentalCarId == rentalCarId);
        }

        public async Task<RentalCar> GetByRentalId(Guid rentalId)
        {
            return await _catalogContext.RentalCars.Where(x => x.RentalId == rentalId).FirstOrDefaultAsync();
        }

        public async Task<List<RentalCar>> GetByRentalIdAsync(Guid rentalId)
        {
            return await _catalogContext.RentalCars.Where(x => x.RentalId == rentalId).ToListAsync();
        }

        public async Task<RentalCar?> GetRental( Guid carId)
        {
            return await _catalogContext.RentalCars.Where(x => x.CarId == carId).FirstOrDefaultAsync();
        }

        public void Update(RentalCar rentalCar)
        {
            _catalogContext.RentalCars.Update(rentalCar);
            _catalogContext.SaveChanges();
        }
    }
}
