using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.BuildingBlocks.Domain;

namespace OnlineRentCar.Modules.Catalog.Application.Owners.ReverseRegisterOwner
{
    public class ReverseRegisterOwnerCommand : CommandBase<Result>
    {
        public string Username { get; set; }
        public ReverseRegisterOwnerCommand(string username)
        {
            Username = username;
        }
    }
}
