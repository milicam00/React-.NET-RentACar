using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using OnlineLibary.Modules.Catalog.Application.Configuration.Commands;
using OnlineRentCar.BuildingBlocks.Application.Emails;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscriptions;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscriptions;
using OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscriptions;
using OnlineRentCar.Modules.Catalog.Domain.RentalCars.RentalCarSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Rentals.RentalSubscription;

namespace OnlineRentCar.Modules.Catalog.Application.Rentals.CreateRental
{
    public class CreateRentalCommandHandler : ICommandHandler<CreateRentalCommand, Result>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly ICarRepository _carRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IRentalCarRepository _rentalCarRepository;
        private readonly IEmailService _emailService;
        private readonly IClientRepository _clientRepository;

        public CreateRentalCommandHandler(IRentalRepository rentalRepository, ICarRepository carRepository, ILocationRepository locationRepository, IRentalCarRepository rentalCarRepository, IEmailService emailService,IClientRepository clientRepository)
        {
            _rentalRepository = rentalRepository;
            _carRepository = carRepository;
            _locationRepository = locationRepository;
            _rentalCarRepository = rentalCarRepository;
            _emailService = emailService;
            _clientRepository = clientRepository;
        }

        public async Task<Result> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
        {
            string body = "";
            List<Guid> carIds = new List<Guid>();
            foreach (var carRentalRequest in request.CarRentals)
            {
                carIds.Add(carRentalRequest.CarId);
            }

            foreach (var id in carIds)
            {
                Car checkCar = await _carRepository.GetByIdAsync(id);
                if (checkCar == null)
                {
                    return Result.Failure("Car with id : " + id + " does not exist.");
                }
                if (checkCar.IsAvailable == false)
                {
                    return Result.Failure("The car with id: " + id + " is not available.");
                }
                checkCar.IsAvailable = false;
                _carRepository.UpdateCar(checkCar);
            }
            Client client = await _clientRepository.GetByUsername(request.ClientId);
            int totalRentals = await _rentalRepository.GetTotalRentalsForClient(client.ClientId);
            if (totalRentals > 5)
            {
               
                foreach (var carRentalRequest in request.CarRentals)
                {
                    var car = await _carRepository.GetByIdAsync(carRentalRequest.CarId);
                    car.DailyRate *= 0.8; 
                    
                }
            }
            Rental rental = Rental.Create(client.ClientId, request.CarRentals.Select(cr => cr.CarId).ToList(),request.Date);

            await _rentalRepository.AddAsync(rental);

            foreach (var rent in rental.RentalCars)
            {
                var carRentalRequest = request.CarRentals.FirstOrDefault(cr => cr.CarId == rent.CarId);
                if (carRentalRequest != null)
                {
                    rent.NumberOfDays = carRentalRequest.NumberOfDays;
                }
                Car car = await _carRepository.GetByIdAsync(rent.CarId);
                Location location = await _locationRepository.GetByIdAsync(car.LocationId);
                body += $"-Model: {car.Model}\n";
                body += $"-Marka: {car.Brand}\n";
                body += $"-Boja: {car.Color}\n";
                body += $"-Cena po danu: {car.DailyRate}\n";
                body += $"-Poslovnica: {location.LocationName}\n";
                body += $"-Broj dana: {rent.NumberOfDays}\n";


                rent.RentalCost = car.DailyRate * rent.NumberOfDays;

                body += $"-Ukupan iznos za plaćanje: {rent.RentalCost}\n\n";
            }
            body += $"-Datum iznajmljivanja: {request.Date}\n";
            body += $"Želimo Vam prijatnu vožnju!";
           await _emailService.SendEmailAsync("mileticmilica246@gmail.com", "Potvrda o iznajmljivanju automobila", "Uspešno ste iznajmili automobil:\n\n" + body);
            return Result.Success("Successfully rental");
        }
    }
}
