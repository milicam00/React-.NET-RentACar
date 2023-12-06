using OnlineRentCar.Modules.UserAccess.Application.Configuration.Commands;
using OnlineRentCar.Modules.UserAccess.Domain.Users;

namespace OnlineRentCar.Modules.UserAccess.Application.ChangeUsername
{
    public class ChangeUsernameCommandHandler : ICommandHandler<ChangeUsernameCommand, List<UserRole>>
    {
        private readonly IUserRepository _userRepository;

        public ChangeUsernameCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserRole>> Handle(ChangeUsernameCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetByIdAsync(request.UserId);
            User existingReaderWithNewUsername = await _userRepository.GetByUsernameAsync(request.NewUsername);

            if (user != null && existingReaderWithNewUsername == null)
            {
                user.ChangeUsername(request.NewUsername);
                _userRepository.UpdateUser(user);
            }
            return user.Roles;
        }
    }
}
