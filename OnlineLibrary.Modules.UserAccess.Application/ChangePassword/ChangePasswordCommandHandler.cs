using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.UserAccess.Application.Authentication;
using OnlineRentCar.Modules.UserAccess.Application.Configuration.Commands;
using OnlineRentCar.Modules.UserAccess.Domain.Users;

namespace OnlineRentCar.Modules.UserAccess.Application.ChangePassword
{
    public class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand,Result>
    {
        private readonly IUserRepository _userRepository;

        public ChangePasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetByIdAsync(request.UserId);

            if(user == null)
            {
                return Result.Failure("User doesn not exist");
            }

            if(!PasswordManager.VerifyHashedPassword(user.Password,request.OldPassword))
            {
                return Result.Failure("Incorrect password");
            }          

            var newPassword = PasswordManager.HashPassword(request.NewPassword);
            user.Password = newPassword;
            _userRepository.UpdateUser(user);
            return Result.Success("Successfully changed password");

        }

        
    }
}
