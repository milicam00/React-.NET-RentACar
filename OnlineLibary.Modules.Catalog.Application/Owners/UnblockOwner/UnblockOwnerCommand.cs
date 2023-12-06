using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.BuildingBlocks.Domain;

namespace OnlineRentCar.Modules.Catalog.Application.Owners.UnblockOwner
{
    public class UnblockOwnerCommand : CommandBase<Result>
    {
        public UnblockOwnerCommand(string userName)
        {
            UserName = userName;
        }
        public string UserName { get; set; }
    }
}
