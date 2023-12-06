namespace OnlineRentCar.API.Modules.Catalog.Locations.Requests
{
    public class CreateLocationRequest
    {
        public string LocationName {  get; set; }   
        public string ContactNumber {  get; set; }
        public string Email {  get; set; }
        public string OwnerUsername { get; set; }
        public string Address { get; set; } 
    }
}
