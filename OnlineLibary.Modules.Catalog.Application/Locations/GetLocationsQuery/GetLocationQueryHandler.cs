using Dapper;
using OnlineLibary.Modules.Catalog.Application.Configuration.Queries;
using OnlineRentCar.BuildingBlocks.Application.Data;
using OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Application.Locations.GetLocationsQuery
{
    public class GetLocationQueryHandler : IQueryHandler<GetLocationQuery, List<LocationDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IOwnerRepository _ownerRepository;

        public GetLocationQueryHandler(ISqlConnectionFactory sqlConnectionFactory,IOwnerRepository ownerRepository)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _ownerRepository = ownerRepository;
        }

        public async Task<List<LocationDto>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            Owner owner =await _ownerRepository.GetByUsername(request.OwnerUsername);
            var connection = _sqlConnectionFactory.GetOpenConnection();

            string sql = "SELECT " +
                $"[LocationId] AS [{nameof(LocationDto.LocationId)}], " +
                $"[LocationName] AS [{nameof(LocationDto.LocationName)}], " +
                $"[IsActive] AS [{nameof(LocationDto.IsActive)}], " +
                $"[ContactNumber] AS [{nameof(LocationDto.ContactNumber)}], " +
                $"[Email] AS [{nameof(LocationDto.Email)}] " +
                 "FROM [Locations] AS [Locations] " +
                 "WHERE [OwnerId] = @OwnerId";
            var parameters = new {OwnerId = owner.OwnerId};

            return (await connection.QueryAsync<LocationDto>(sql,parameters)).AsList();
        }
    }
}
