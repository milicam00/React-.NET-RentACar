namespace OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscription
{
    public class LocationDto
    {
        public Guid LocationId { get; set; }
        public string ContactNumber {  get; set; }  
        public string LocationName { get; set; }
        public bool IsActive { get; set; }     
        public string Email { get; set; }
        
    }
}
