using OnlineLibary.Modules.Catalog.Application.Configuration.Commands;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Application.Cars.DeleteCar
{
    public class DeleteCarCommandHandler : ICommandHandler<DeleteCarCommand, Result>
    {
        private readonly ICarRepository _carRepository;
        public DeleteCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<Result> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            Car car = await _carRepository.GetByIdAsync(request.CarId);
            if (car == null)
            {
                return Result.Failure("This car does not exist.");
            }
            else
            {
                _carRepository.DeleteCar(car);
                return Result.Success("Car is deleted.");
            }

        }
    }
}
