using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.UserAccess.Application.Authentication;
using OnlineRentCar.Modules.UserAccess.Application.Configuration.Commands;
using OnlineRentCar.Modules.UserAccess.Domain.Users;

namespace OnlineRentCar.Modules.UserAccess.Application.AddOwner
{
    public class RegisterOwnerCommandHandler : ICommandHandler<RegisterOwnerCommand,Result>
    {
        private readonly IUserRepository _userRepository;

        public RegisterOwnerCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
      
        }

        public async Task<Result> Handle(RegisterOwnerCommand request, CancellationToken cancellationToken)
        {
            var password = PasswordManager.HashPassword(request.Password);

            var user = User.CreateOwner(
                request.Username,
                password,
                request.Email,
                request.FirstName,
                request.LastName
                );
            await _userRepository.AddAsync(user);

            return Result.Success("Successfully registartion!");

        }
    }
}
