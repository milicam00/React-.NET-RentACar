using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.BuildingBlocks.Domain;

namespace OnlineRentCar.Modules.Catalog.Application.Rentals.CreateRental
{
    public class CreateRentalCommand : CommandBase<Result>
    {
        public CreateRentalCommand(string clientId, List<CarRentalRequest> carRentals,DateTime date)
        {
            ClientId = clientId;
            CarRentals = carRentals;
            Date = date;    
        }
        public string ClientId { get; set; }
        public List<CarRentalRequest> CarRentals { get; set; }
        public DateTime Date { get; set; }
    }

    public class CarRentalRequest
    {
        public Guid CarId { get; set; }
        public int NumberOfDays { get; set; }
    }

}
