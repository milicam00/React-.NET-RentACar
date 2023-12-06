using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.UserAccess.Application.Configuration.Commands;
using OnlineRentCar.Modules.UserAccess.Domain.Users;

namespace OnlineRentCar.Modules.UserAccess.Application.BlockUser
{
    public class BlockUserCommandHandler : ICommandHandler<BlockUserCommand, Result>
    {
        private readonly IUserRepository _userRepository;

        public BlockUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(BlockUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = await _userRepository.GetByUsernameAsync(request.Username);
                if (user == null)
                {
                    return Result.Failure("User does not exist.");
                }

                if (!user.IsActive)
                {
                    return Result.Failure("User is already blocked.");
                }
                user.BlockUser();
                _userRepository.UpdateUser(user);

                return Result.Success("User is blocked.");

            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx)
                {
                    return Result.Failure("Database error: " + sqlEx.Message);
                }
                return Result.Failure("Database error.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Error message: " + ex.Message);
            }
        }
    }
}
