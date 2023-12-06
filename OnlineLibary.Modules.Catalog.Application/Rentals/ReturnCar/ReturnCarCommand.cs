using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.BuildingBlocks.Domain;

namespace OnlineRentCar.Modules.Catalog.Application.Rentals.ReturnCar
{
    public class ReturnCarCommand : CommandBase<Result>
    {
        public Guid RentalCarId { get; set; }

        public ReturnCarCommand(Guid rentalCarId)
        {
            RentalCarId = rentalCarId;
        }

    }
}
