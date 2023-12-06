using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.BuildingBlocks.Domain;

namespace OnlineRentCar.Modules.Catalog.Application.Clients.ReverseRegisterClient
{
    public class ReverseRegisterUserCommand : CommandBase<Result>
    {
        public string Username { get; set; }
        public ReverseRegisterUserCommand(string username)
        {
            Username = username;
        }
    }
}
