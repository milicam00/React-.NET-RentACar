using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.UserAccess.Application.Contracts;

namespace OnlineRentCar.Modules.UserAccess.Application.UnblockUser
{
    public class UnblockUserCommand : CommandBase<Result>
    {
        public UnblockUserCommand(string username) 
        {
            Username = username;
        }
        public string Username { get; set; }
    }
}
