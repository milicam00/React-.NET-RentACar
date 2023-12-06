using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.UserAccess.Application.Contracts;

namespace OnlineRentCar.Modules.UserAccess.Application.ReverseRegisterUser
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
