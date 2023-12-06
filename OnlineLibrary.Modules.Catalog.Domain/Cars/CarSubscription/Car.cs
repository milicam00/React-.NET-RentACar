using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscriptions;
using OnlineRentCar.Modules.Catalog.Domain.RentalCars.RentalCarSubscription;

namespace OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscriptions
{
    public class Car : Entity, IAggregateRoot
    {
        public Guid CarId { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string VehicleType { get; set; }
        public double DailyRate { get; set; }
        public bool IsAvailable { get; set; }
        public double AverageRating { get; set; }
        public int NumberOfRatings { get; set; }
        public int NumberOfPassangers { get; set; }
        public string TransmissionType { get; set; }
        public int NumberOfDoors { get; set; }
        public string Image { get; set; }
        public double Mileage { get; set; }
        public string FuelType { get; set; }
        public Guid LocationId { get; set; }
        public Location Location { get; set; }
        public List<RentalCar> RentalCars { get; set; }

        public Car()
        {
            CarId = Guid.NewGuid();
            RentalCars = new List<RentalCar>();
        }

        public Car(string model, string brand, string color, int year, string vehicleType, double dailyRate,
                   int numberOfPassangers, string transmissionType, int numberOfDoors,string image,double mileage,string fuelType, Guid locationId)
        {
            CarId = Guid.NewGuid();
            Model = model;
            Brand = brand;
            Color = color;
            Year = year;
            VehicleType = vehicleType;
            DailyRate = dailyRate;
            IsAvailable = true;
            NumberOfPassangers = numberOfPassangers;
            TransmissionType = transmissionType;
            NumberOfDoors = numberOfDoors;
            Image = image;
            Mileage = mileage;
            FuelType = fuelType;
            LocationId = locationId;
        }

        public static Car Create(string model, string brand, string color, int year, string vehicleType, double dailyRate,
                   int numberOfPassangers, string transmissionType, int numberOfDoors,string image,double mileage,string fuelType, Guid locationId)
        {
            return new Car(model, brand, color, year, vehicleType, dailyRate, numberOfPassangers, transmissionType, numberOfDoors,image,mileage,fuelType, locationId);
        }

        public void EditCar(
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
            string fuelType)
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
        }
    }


}
