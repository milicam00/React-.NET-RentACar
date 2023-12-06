using OnlineLibary.Modules.Catalog.Application.Configuration.Queries;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscription;

namespace OnlineRentCar.Modules.Catalog.Application.Owners.GetOwners
{
    public class GetOwnersQueryHandler : IQueryHandler<GetOwnersQuery, Result>
    {
        private readonly IOwnerRepository _ownerRepository;
        public GetOwnersQueryHandler(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<Result> Handle(GetOwnersQuery request, CancellationToken cancellationToken)
        {
            var owners = await _ownerRepository.GetAll();
            return Result.Success(owners);
        }
    }
}
