using OnlineRentCar.Modules.Catalog.Application.Rentals.CreateRental;

namespace OnlineRentCar.API.Modules.Catalog.Rentals.Requests
{
    public class RentalRequest
    {
        public string ClientId { get; set; }
        public List<CarRentalRequest> CarRentalRequests { get; set; }
        public DateTime Date { get; set; }  
    }
}
