using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.BuildingBlocks.Domain;

namespace OnlineRentCar.Modules.Catalog.Application.Owners.BlockOwner
{
    public class BlockOwnerCommand : CommandBase<Result>
    {
        public BlockOwnerCommand(string userName)
        {
            UserName = userName;
        }
        public string UserName { get; set; }
    }
}
