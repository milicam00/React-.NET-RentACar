using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.UserAccess.Application.Authentication;
using OnlineRentCar.Modules.UserAccess.Application.Configuration.Commands;
using OnlineRentCar.Modules.UserAccess.Domain.Users;

namespace OnlineRentCar.Modules.UserAccess.Application.AddReader
{
    public class RegisterClientCommandHandler : ICommandHandler<RegisterClientCommand, Result>
    {
        private readonly IUserRepository _userRepository;
        public RegisterClientCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
        {
            var password = PasswordManager.HashPassword(request.Password);

            var user = User.CreateClient(
                request.Username,
                password,
                request.Email,
                request.FirstName,
                request.LastName
                );
            await _userRepository.AddAsync(user);

            return Result.Success("Successfully registration!");

        }
    }
}
