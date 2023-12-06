using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.BuildingBlocks.Domain;

namespace OnlineRentCar.Modules.Catalog.Application.Cars.DeleteCar
{
    public class DeleteCarCommand : CommandBase<Result>
    {
        public DeleteCarCommand(Guid carId)
        {
            CarId = carId;
        }
        public Guid CarId { get; set; }
    }
}
