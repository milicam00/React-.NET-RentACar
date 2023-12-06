namespace OnlineRentCar.API.Modules.Catalog.Cars.Requests
{
    public class CarSearchRequest
    {
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public int? Year { get; set; }
        public string? FuelType { get; set; }
        public string? VehicleType { get; set; }
        public int? NumberOfPassangers { get; set; }
        public string? TransmissionType { get; set; }
        public int? NumberOfDoors { get; set; }
    }
}
