using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.BuildingBlocks.Domain;

namespace OnlineRentCar.Modules.Catalog.Application.Clients.BlockClient
{
    public class BlockClientCommand : CommandBase<Result>
    {
        public BlockClientCommand(string userName)
        {
            UserName = userName;
        }
        public string UserName { get; set; }    
    }
}
