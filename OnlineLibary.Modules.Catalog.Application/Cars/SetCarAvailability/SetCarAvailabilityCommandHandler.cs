using OnlineLibary.Modules.Catalog.Application.Configuration.Commands;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Application.Cars.SetCarAvailability
{
    public class SetCarAvailabilityCommandHandler : ICommandHandler<SetCarAvailabilityCommand, bool>
    {
        private readonly ICarRepository _carRepository;
        public SetCarAvailabilityCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<bool> Handle(SetCarAvailabilityCommand request, CancellationToken cancellationToken)
        {
            Car car = await _carRepository.GetByIdAsync(request.CarId);
            if(car == null)
            {
                return false;
            }
            car.IsAvailable = request.IsAvailable;
            _carRepository.UpdateCar(car);
            return true;
        }
    }
}
