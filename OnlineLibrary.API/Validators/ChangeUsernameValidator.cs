using FluentValidation;
using OnlineRentCar.API.Modules.UserAccess.Requests;

namespace OnlineRentCar.API.Validators
{
    public class ChangeUsernameValidator : AbstractValidator<ChangeUsernameRequest>
    {
        public ChangeUsernameValidator()
        {
            RuleFor(x => x.OldUsername)
                 .NotEqual(x => x.NewUsername)
                 .WithMessage("The new username must be different");
        }
    }
}
