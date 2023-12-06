using OnlineRentCar.BuildingBlocks.Domain;

namespace OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscriptions
{
    public class Client : Entity, IAggregateRoot
    {
        public Guid ClientId { get; set; }
        public string UserName { get; private set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsBlocked { get; set; }

        public Client()
        {
            ClientId = Guid.NewGuid();
            IsBlocked = false;
        }
        public Client(Guid readerId, string userName, string email, string firstName, string lastName)
        {
            ClientId = readerId;
            UserName = userName;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            IsBlocked = false;
        }

        public static Client CreateUser(string username, string email, string firstName, string lastName)
        {
            return new Client(
                Guid.NewGuid(),
                username,
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
            this.UserName = username;
        }
    }
}
