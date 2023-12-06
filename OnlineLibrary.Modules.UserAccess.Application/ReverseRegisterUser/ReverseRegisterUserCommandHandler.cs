using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.UserAccess.Application.Configuration.Commands;
using OnlineRentCar.Modules.UserAccess.Domain.Users;

namespace OnlineRentCar.Modules.UserAccess.Application.ReverseRegisterUser
{
    public class ReverseRegisterUserCommandHandler : ICommandHandler<ReverseRegisterUserCommand, Result>
    {
        private readonly IUserRepository _userRepository;
        public ReverseRegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result> Handle(ReverseRegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = await _userRepository.GetByUsernameAsync(request.Username);
                if (user == null)
                {
                    return Result.Failure("User does not exist.");
                }
                _userRepository.DeleteUser(user);
                return Result.Success("Deleted user");
            }
            catch (Exception ex)
            {
                return Result.Failure("Error message: " + ex.Message);
            }

        }
    }
}
