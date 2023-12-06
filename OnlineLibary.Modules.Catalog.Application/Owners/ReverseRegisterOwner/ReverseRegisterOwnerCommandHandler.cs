using OnlineLibary.Modules.Catalog.Application.Configuration.Commands;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRentCar.Modules.Catalog.Application.Owners.ReverseRegisterOwner
{
    public class ReverseRegisterOwnerCommandHandler : ICommandHandler<ReverseRegisterOwnerCommand, Result>
    {
        private readonly IOwnerRepository _ownerRepository;
        public ReverseRegisterOwnerCommandHandler(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<Result> Handle(ReverseRegisterOwnerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Owner owner = await _ownerRepository.GetByUsername(request.Username);
                if (owner == null)
                {
                    return Result.Failure("User does not exist.");
                }
                _ownerRepository.Delete(owner);
                return Result.Success("Deleted user");
            }
            catch (Exception ex)
            {
                return Result.Failure("Error message: " + ex.Message);
            }
        }
    }
}
