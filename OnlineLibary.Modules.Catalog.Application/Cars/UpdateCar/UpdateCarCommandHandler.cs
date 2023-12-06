using OnlineLibary.Modules.Catalog.Application.Configuration.Commands;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Application.Cars.UpdateCar
{
    public class UpdateCarCommandHandler : ICommandHandler<UpdateCarCommand, Result>
    {
        private readonly ICarRepository _carRepository;
        public UpdateCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<Result> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = await _carRepository.GetByIdAsync(request.CarId);
            if (car == null)
            {
                return Result.Failure("This car does not exist.");
            }
            else
            {
                car.EditCar(request.Model, request.Brand, request.Color, request.Year, request.VehicleType, request.DailyRate, request.NumberOfPassangers, request.TransmissionType, request.NumberOfDoors,request.Image,request.Mileage,request.FuelType);
                _carRepository.UpdateCar(car);
                return Result.Success("Car is successfully updated!");
            }

        }
    }
}
