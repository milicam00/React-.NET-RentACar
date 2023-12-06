using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscriptions;
using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscriptions
{
    public class Location : Entity, IAggregateRoot
    {
        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
        public bool IsActive { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public List<Car> Cars { get; set; }
        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }

        public Location()
        {
            LocationId = Guid.NewGuid();
        }

        public Location(string locationName,string contactNumber, string email, Guid ownerId,string address)
        {
            LocationName = locationName;
            ContactNumber = contactNumber;
            IsActive = true;
            Email = email;
            OwnerId = ownerId;
            Address = address;
        }

        public static Location CreateLocation(string locationName, string contactNumber, string email, Guid ownerId,string address)
        {
            return new Location(locationName,contactNumber, email,ownerId,address);
        }

        public void EditActivate(bool isActive)
        {
            IsActive = isActive;
        }
        public void ActivateLocation()
        {
            IsActive = true;
        }
        public void DeactivateLocation()
        {
            IsActive = false;
        }
    }
}
