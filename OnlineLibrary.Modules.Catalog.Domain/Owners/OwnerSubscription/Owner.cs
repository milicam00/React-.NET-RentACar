using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscriptions
{
    public class Owner : Entity, IAggregateRoot
    {
        public Guid OwnerId { get; set; }
        public string UserName { get; private set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsBlocked { get; set; }
        public List<Location> Locations { get; set; }

        public Owner()
        {
            OwnerId = Guid.NewGuid();
            IsBlocked = false;
        }

        public Owner(Guid ownerId, string userName, string email, string firstName, string lastName)
        {
            OwnerId = ownerId;
            UserName = userName;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            IsBlocked = false;

        }

        public static Owner CreateOwner(string userName, string email, string firstName, string lastName)
        {
            return new Owner(
                Guid.NewGuid(),
                userName,
                email,
                firstName,
                lastName);
        }

        public void Block()
        {
            IsBlocked = true;
        }
        public void Unblock()
        {
            IsBlocked = false;
        }

        public void ChangeUsername(string username)
        {
            UserName = username;
        }
    }
}
