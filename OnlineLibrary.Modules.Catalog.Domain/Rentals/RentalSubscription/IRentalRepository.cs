namespace OnlineRentCar.Modules.Catalog.Domain.Rentals.RentalSubscription
{
    public interface IRentalRepository
    {
        Task AddAsync(Rental rental);
        Task<Rental> GetByIdAsync(Guid rentalId);
        Task<Rental> GetByClientId(Guid clientId);
        Task<int> GetTotalRentalsForClient(Guid clientId);
    }
}
