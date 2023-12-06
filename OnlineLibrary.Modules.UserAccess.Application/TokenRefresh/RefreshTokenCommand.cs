using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.UserAccess.Application.Contracts;

namespace OnlineRentCar.Modules.UserAccess.Application.TokenRefresh
{
    public class RefreshTokenCommand : CommandBase<Result>
    {
        public RefreshTokenCommand(string refreshToken)
        { 
            RefreshToken = refreshToken;
        }
        public string RefreshToken { get; set; }
    }
}
