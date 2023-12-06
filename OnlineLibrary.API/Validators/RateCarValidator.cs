using FluentValidation;
using OnlineRentCar.API.Modules.Catalog.Rentals.Requests;

namespace OnlineRentCar.API.Validators
{
    public class RateCarValidator : AbstractValidator<RateRequest>
    {
        public RateCarValidator() 
        {
            RuleFor(request => request.Rate)
                .InclusiveBetween(1, 5)
                .WithMessage("Rate must be between 1 and 5.");
        }
    }
}
