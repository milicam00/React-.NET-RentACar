using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.BuildingBlocks.Domain;

namespace OnlineRentCar.Modules.Catalog.Application.Cars.AddCar
{
    public class AddCarCommand : CommandBase<Result>
    {
        public AddCarCommand(
            string model,
            string brand,
            string color,
            int year,
            string vehicleType,
            double dailyRate,
            int numOfPassangers,
            string transmissionType,
            int numOfDoors,
            string image,
            double mileage,
            string fuelType,
            Guid locationId
            )
        {
            Model = model;
            Brand = brand;
            Color = color;
            Year = year;
            VehicleType = vehicleType;
            DailyRate = dailyRate;
            NumberOfPassangers = numOfPassangers;
            TransmissionType = transmissionType;
            NumberOfDoors = numOfDoors;
            Image = image;
            Mileage = mileage;
            FuelType = fuelType;    
            LocationId = locationId;
        }

        public string Model { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string VehicleType { get; set; }
        public double DailyRate { get; set; }
        public int NumberOfPassangers { get; set; }
        public string TransmissionType { get; set; }
        public int NumberOfDoors { get; set; }
        public string Image { get; set; }
        public double Mileage { get; set; }
        public string FuelType { get; set; }    
        public Guid LocationId { get; set; }

    }
}
