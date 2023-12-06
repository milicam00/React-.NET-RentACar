using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.UserAccess.Application.Contracts;

namespace OnlineRentCar.Modules.UserAccess.Application.ResetPassword
{
    public class ResetPasswordCommand : CommandBase<Result>
    {
        public int Code { get; set; }
        public string UserName { get; set; }          
        public string NewPassword { get; set; }
        public ResetPasswordCommand(int code,string username,string newPassword)
        {
            Code = code;
            UserName = username;
            NewPassword = newPassword;
        }
    }
}
