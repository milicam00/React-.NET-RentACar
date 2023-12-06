using OnlineLibary.Modules.Catalog.Application.Configuration.Queries;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscription;

namespace OnlineRentCar.Modules.Catalog.Application.Cars.GetCar
{
    public class GetCarQuery : QueryBase<List<CarDto>>
    {
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public int? Year { get; set; }
        public string? FuelType { get; set; }
        public string? VehicleType { get; set; }
        public int? NumberOfPassangers { get; set; }
        public string? TransmissionType {  get; set; }
        public int? NumberOfDoors { get; set; }

        public GetCarQuery(string? model, string? brand, int? year, string? fuelType, string? vehicleType, int? numberOfPassangers, string? transmissionType, int? numberOfDoors)
        {
            Model = model;
            Brand = brand;
            Year = year;
            FuelType = fuelType;
            VehicleType = vehicleType;
            NumberOfPassangers = numberOfPassangers;
            TransmissionType = transmissionType;
            NumberOfDoors = numberOfDoors;
        }
    }
}
