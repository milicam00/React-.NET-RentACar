using OnlineLibary.Modules.Catalog.Application.Configuration.Commands;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscriptions;
using OnlineRentCar.Modules.Catalog.Domain.RentalCars.RentalCarSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Rentals.RentalSubscription;

namespace OnlineRentCar.Modules.Catalog.Application.Rentals.ReturnCar
{
    public class ReturnCarCommandHandler : ICommandHandler<ReturnCarCommand, Result>
    {
        private readonly IRentalCarRepository _rentalCarRepository;
        private readonly ICarRepository _carRepository;
        private readonly IRentalRepository _rentalRepository;
        public ReturnCarCommandHandler(IRentalCarRepository rentalCarRepository, ICarRepository carRepository, IRentalRepository rentalRepository)
        {
            _rentalCarRepository = rentalCarRepository;
            _carRepository = carRepository;
            _rentalRepository = rentalRepository;
        }

        public async Task<Result> Handle(ReturnCarCommand request, CancellationToken cancellationToken)
        {

            RentalCar rentalCar = await _rentalCarRepository.GetByRentalId(request.RentalCarId);
            rentalCar.ReturnDate = DateTime.Now;
            _rentalCarRepository.Update(rentalCar);

            Car car = await _carRepository.GetByIdAsync(rentalCar.CarId);
            car.IsAvailable = true;
            _carRepository.UpdateCar(car);

          
            return Result.Success("Car is returned.");






        }
    }
}
