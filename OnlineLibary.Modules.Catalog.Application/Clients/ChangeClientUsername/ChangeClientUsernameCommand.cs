using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.BuildingBlocks.Domain;

namespace OnlineRentCar.Modules.Catalog.Application.Clients.ChangeClientUsername
{
    public class ChangeClientUsernameCommand : CommandBase<Result>
    {
        public ChangeClientUsernameCommand(string oldUsername, string newUsername)
        {
            OldUsername = oldUsername;
            NewUsername = newUsername;
        }
        public string OldUsername { get; set; }
        public string NewUsername { get; set; }
    }
}
