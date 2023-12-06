using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.UserAccess.Application.Contracts;

namespace OnlineRentCar.Modules.UserAccess.Application.Logout
{
    public class LogoutCommand : CommandBase<Result>
    {
        public LogoutCommand(string refreshToken)
        {
            RefreshToken = refreshToken;
        }
        public string RefreshToken { get; set; }
    }
}
