using OnlineLibary.Modules.Catalog.Application.Configuration.Commands;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscriptions;
using OnlineRentCar.Modules.Catalog.Domain.RentalCars.RentalCarSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Rentals.RentalSubscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OnlineRentCar.Modules.Catalog.Application.Rentals.RateCar
{
    public class RateCarCommandHandler : ICommandHandler<RateCarCommand, Result>
    {
        private readonly IRentalCarRepository _rentalCarRepository;
        private readonly ICarRepository _carRepository;
        private readonly IRentalRepository _rentalRepository;

        public RateCarCommandHandler(IRentalCarRepository rentalCarRepository, ICarRepository carRepository,IRentalRepository rentalRepository)
        {
            _rentalCarRepository = rentalCarRepository;
            _carRepository = carRepository;
            _rentalRepository = rentalRepository;
        }

        public async Task<Result> Handle(RateCarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                RentalCar? rental = await _rentalCarRepository.GetRental( request.CarId);
                if(rental!=null)
                {
                    rental.RateCar(request.Rate, request.Text);
                    Car car = await _carRepository.GetByIdAsync(rental.CarId);
                    car.NumberOfRatings++;
                    double newAverageRating = ((car.AverageRating * (car.NumberOfRatings - 1)) + request.Rate) / (car.NumberOfRatings);
                    car.AverageRating = newAverageRating;
                    _carRepository.UpdateCar(car);
                    _rentalCarRepository.Update(rental);
                }
                return Result.Success("Car is successfully rated.");
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}
