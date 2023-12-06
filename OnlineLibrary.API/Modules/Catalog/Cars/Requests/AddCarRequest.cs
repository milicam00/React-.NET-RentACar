namespace OnlineRentCar.API.Modules.Catalog.Cars.Requests
{
    public class AddCarRequest
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string VehicleType { get; set; }
        public double DailyRate { get; set; }
        public int NumberOfPassangers { get; set; }
        public string TransmissionType { get; set; }
        public int NumberOfDoors { get; set; }
        public string Image {  get; set; }
        public double Mileage { get; set; } 
        public string FuelType { get; set; }    
        public Guid LocationId { get; set; }
    }
}
