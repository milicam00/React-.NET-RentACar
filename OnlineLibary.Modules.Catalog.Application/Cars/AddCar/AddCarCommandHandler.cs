using OnlineLibary.Modules.Catalog.Application.Configuration.Commands;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Application.Cars.AddCar
{
    public class AddCarCommandHandler : ICommandHandler<AddCarCommand, Result>
    {
        private readonly ICarRepository _carRepository;

        public AddCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;

        }

        public async Task<Result> Handle(AddCarCommand request, CancellationToken cancellationToken)
        {
            var car = Car.Create(
                request.Model,
                request.Brand,
                request.Color,
                request.Year,
                request.VehicleType,
                request.DailyRate,
                request.NumberOfPassangers,
                request.TransmissionType,
                request.NumberOfDoors,
                request.Image,
                request.Mileage,
                request.FuelType,
                request.LocationId);

            await _carRepository.AddAsync(car);
            return Result.Success("Car is successfully created!");

        }
    }
}
