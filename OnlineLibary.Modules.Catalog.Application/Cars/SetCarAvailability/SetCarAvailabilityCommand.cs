using OnlineLibary.Modules.Catalog.Application.Contracts;

namespace OnlineRentCar.Modules.Catalog.Application.Cars.SetCarAvailability
{
    public class SetCarAvailabilityCommand : CommandBase<bool>
    {
        public Guid CarId { get; set; } 
        public bool IsAvailable { get; set; }
        public SetCarAvailabilityCommand(Guid carId,bool isAvailable)
        { 
            CarId = carId;
            IsAvailable = isAvailable;
        }
    }
}
