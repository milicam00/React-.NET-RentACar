using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.UserAccess.Application.Configuration.Commands;
using OnlineRentCar.Modules.UserAccess.Domain.RefreshTokens;
using OnlineRentCar.Modules.UserAccess.Domain.Users;

namespace OnlineRentCar.Modules.UserAccess.Application.Logout
{
    public class LogoutCommandHandler : ICommandHandler<LogoutCommand, Result>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserRepository _userRepository;
        public LogoutCommandHandler(IRefreshTokenRepository refreshTokenRepository, IUserRepository userRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository = userRepository;
        }
        public async Task<Result> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                RefreshToken refreshToken = await _refreshTokenRepository.GetByToken(request.RefreshToken);
                if (refreshToken == null)
                {
                    return Result.Failure("Refresh token does not exist.");
                }

                Guid userId = refreshToken.UserId;
                User user = await _userRepository.GetByIdAsync(userId);
                if (user == null)
                {
                    return Result.Failure("User does not exist.");
                }

                List<RefreshToken> tokens = await _refreshTokenRepository.GetRefreshTokensByUser(userId);
                foreach (RefreshToken token in tokens)
                {
                    _refreshTokenRepository.RemoveAsync(token);
                }
                return Result.Success("Successfully logout");
            }
            catch (Exception ex)
            {
                return Result.Failure("Error message: " + ex.Message);
            }
        }
    }
}
