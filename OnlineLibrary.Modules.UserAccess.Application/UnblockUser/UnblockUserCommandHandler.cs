using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.UserAccess.Application.Configuration.Commands;
using OnlineRentCar.Modules.UserAccess.Domain.Users;

namespace OnlineRentCar.Modules.UserAccess.Application.UnblockUser
{
    public class UnblockUserCommandHandler : ICommandHandler<UnblockUserCommand, Result>
    {
        private readonly IUserRepository _userRepository;
        public UnblockUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(UnblockUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = await _userRepository.GetByUsernameAsync(request.Username);
                if (user == null)
                {
                    return Result.Failure("User does not exist.");
                }

                if (user.IsActive)
                {
                    return Result.Failure("User is already unblocked.");
                }
                user.UnblockUser();
                _userRepository.UpdateUser(user);

                return Result.Success("User is unblocked.");
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx)
                {
                    if (sqlEx.Number == 547)
                    {
                        return Result.Failure("Referential integrity violaton.");
                    }
                    else if (sqlEx.Number == 2601)
                    {
                        return Result.Failure("Duplicate key violation.");
                    }
                    else
                    {
                        return Result.Failure("Database error: " + sqlEx.Message);
                    }
                }
                else
                {
                    return Result.Failure("Database error.");

                }
            }
            catch (Exception ex)
            {
                return Result.Failure("Error message: " + ex.Message);
            }

        }

    }
}
