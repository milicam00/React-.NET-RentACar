using OnlineLibary.Modules.Catalog.Application.Configuration.Commands;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Application.Cars.GetAllCar
{
    public class GetAllCarCommandHandler : ICommandHandler<GetAllCarCommand, Result>
    {
        public readonly ICarRepository _carRepository;
        public GetAllCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<Result> Handle(GetAllCarCommand request, CancellationToken cancellationToken)
        {
            var cars = await _carRepository.GetAllCars();
            return Result.Success(cars);
        }
    }
}
