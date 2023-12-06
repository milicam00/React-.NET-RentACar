using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.UserAccess.Application.Authentication;
using OnlineRentCar.Modules.UserAccess.Application.Configuration.Commands;
using OnlineRentCar.Modules.UserAccess.Domain.Users;

namespace OnlineRentCar.Modules.UserAccess.Application.ResetPassword
{
    public class ResetPasswordCommandHandler : ICommandHandler<ResetPasswordCommand, Result>
    {
        private readonly IUserRepository _userRepository;

        public ResetPasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            User user =await _userRepository.GetByUsernameAsync(request.UserName);
            if(user!=null)
            {
                if(user.ResetPasswordCode==request.Code && user.ResetPasswordCodeExpiration<DateTime.Now.AddMinutes(20))
                {
                    var newPassword = PasswordManager.HashPassword(request.NewPassword);
                    user.Password = newPassword;
                    _userRepository.UpdateUser(user);
                }
                return Result.Success("Password has been reset.");
            }
            return Result.Failure("User does not exist.");

        }
    }
}
