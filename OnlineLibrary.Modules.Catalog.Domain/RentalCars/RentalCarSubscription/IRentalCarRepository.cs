namespace OnlineRentCar.Modules.Catalog.Domain.RentalCars.RentalCarSubscription
{
    public interface IRentalCarRepository
    {
        Task AddAsync(RentalCar rentalCar);
        Task<RentalCar?> GetByIdAsync(Guid rentalCarId);
        Task<List<RentalCar>> GetByRentalIdAsync(Guid rentalId);
        void Update(RentalCar rentalCar);
        Task<RentalCar> GetRental(Guid carId);
        Task<RentalCar> GetByCarId (Guid carId);    
        Task<RentalCar> GetByRentalId (Guid rentalId);    
    }
}
