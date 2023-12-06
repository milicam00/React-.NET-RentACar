using OnlineLibary.Modules.Catalog.Application.Configuration.Commands;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Application.Owners.RegisterOwner
{
    public class RegisterOwnerCommandHandler : ICommandHandler<RegisterOwnerCommand, Result>
    {
        private readonly IOwnerRepository _ownerRepository;

        public RegisterOwnerCommandHandler(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<Result> Handle(RegisterOwnerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var owner = Owner.CreateOwner(
                request.UserName,
                request.Email,
                request.FirstName,
                request.LastName
                );
                await _ownerRepository.AddAsync(owner);

                return Result.Success("Successfully registration!");
            }
            catch (Exception ex)
            {
                return Result.Failure("Error message: " + ex.Message);
            }
        }
    }
}
