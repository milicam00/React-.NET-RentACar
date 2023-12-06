using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.BuildingBlocks.Domain;

namespace OnlineRentCar.Modules.Catalog.Application.Clients.UnblockClient
{
    public class UnblockClientCommand : CommandBase<Result>
    {
        public UnblockClientCommand(string username)
        {
            UserName = username;
        }
        public string UserName { get; set; }
    }
}
