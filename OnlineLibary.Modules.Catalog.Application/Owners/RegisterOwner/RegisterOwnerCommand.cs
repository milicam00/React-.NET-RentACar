using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.BuildingBlocks.Domain;

namespace OnlineRentCar.Modules.Catalog.Application.Owners.RegisterOwner
{
    public class RegisterOwnerCommand : CommandBase<Result>
    {
        public RegisterOwnerCommand(
            string username,
            string email,
            string firstName,
            string lastName
            )
        {
            UserName = username;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
