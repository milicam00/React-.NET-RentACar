using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.UserAccess.Application.Contracts;

namespace OnlineRentCar.Modules.UserAccess.Application.ResetPasswordRequest
{
    public class ResetPasswordRequestCommand : CommandBase<Result>
    {
        public ResetPasswordRequestCommand(string userName) 
        {
            UserName = userName;
        }
        public string UserName { get; set; }
        

    }
}
