using OnlineRentCar.BuildingBlocks.Application.Emails;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.UserAccess.Application.Configuration.Commands;
using OnlineRentCar.Modules.UserAccess.Domain.Users;

namespace OnlineRentCar.Modules.UserAccess.Application.ResetPasswordRequest
{
    public class ResetPasswordRequestCommandHandler : ICommandHandler<ResetPasswordRequestCommand, Result>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
              
        public ResetPasswordRequestCommandHandler(IUserRepository userRepository,IEmailService emailService)
        {
            _userRepository = userRepository;        
            _emailService = emailService;
        }


        public async Task<Result> Handle(ResetPasswordRequestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Random random = new Random();
                User user = await _userRepository.GetByUsernameAsync(request.UserName);
                int resetCode = random.Next(10000, 100000);

                if (user == null)
                {
                    return Result.Failure("User does not exist.");
                }

                user.ResetPasswordCode = resetCode;
                user.ResetPasswordCodeExpiration = DateTime.UtcNow.AddMinutes(20);
                _userRepository.UpdateUser(user);

                await _emailService.SendEmailAsync(user.Email, "Zahtev za resetovanje lozinke", "Vaš kod za resetovanje lozinke je : " + resetCode + "\n");
                return Result.Success("Code is sent on your email");
            }
            catch (Exception ex)
            {
                return Result.Failure("Error message: " + ex.Message);
            }
        }
    }
}
