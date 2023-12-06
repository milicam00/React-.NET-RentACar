using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.BuildingBlocks.Domain;

namespace OnlineRentCar.Modules.Catalog.Application.Owners.ChangeOwnerUsernameCommand
{
    public class ChangeOwnerUsernameCommand : CommandBase<Result>
    {
        public ChangeOwnerUsernameCommand(string oldUsername, string newUsername)
        {
            OldUsername = oldUsername;
            NewUsername = newUsername;
        }
        public string OldUsername { get; set; }
        public string NewUsername { get; set; }
    }
}
