using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.BuildingBlocks.Domain;

namespace OnlineRentCar.Modules.Catalog.Application.Locations.CreateLocation
{
    public class CreateLocationCommand : CommandBase<Result>
    {
        public CreateLocationCommand(
            string locationName,
            string contactNumber,
            string email,
            string ownerUsername,
            string address)
        {
            LocationName = locationName;
            ContactNumber = contactNumber;
            Email = email;
            OwnerUsername = ownerUsername;
            Address = address;
        }

        public string LocationName { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string OwnerUsername { get; set; }
        public string Address { get; set; }
    }
}
