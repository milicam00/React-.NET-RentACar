using Dapper;
using OnlineLibary.Modules.Catalog.Application.Configuration.Queries;
using OnlineRentCar.BuildingBlocks.Application.Data;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRentCar.Modules.Catalog.Application.Owners.GetPreviousRentalsOwner
{
    public class GetPreviousRentalsOwnerQueryHandler : IQueryHandler<GetPreviousRentalsOwnerQuery, Result>
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        private readonly IOwnerRepository _ownerRepository;
        public GetPreviousRentalsOwnerQueryHandler(ISqlConnectionFactory connectionFactory, IOwnerRepository ownerRepository)
        {
            _connectionFactory = connectionFactory;
            _ownerRepository = ownerRepository;
        }

        public async Task<Result> Handle(GetPreviousRentalsOwnerQuery request, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.GetByUsername(request.OwnerUsername);
            if (owner == null)
            {
                return Result.Failure("This owner does not exist");
            }
            var connection = _connectionFactory.GetOpenConnection();
            var parameters = new { OwnerId = owner.OwnerId };

            string sql = "SELECT " +
            $"L.[LocationName] AS [LocationName], " +
            $"C.[CarId] AS [CarId], " +
            $"C.[Model] AS [Model], " +
            $"C.[Brand] AS [Brand], " +
            $"C.[VehicleType] AS [VehicleType], " +
            $"C.[TransmissionType] AS [TransmissionType], " +
            $"R.[RentalId] AS [RentalId], " +
            $"R.[RentalDate] AS [RentalDate], " +
            $"A.[ReturnDate] AS [ReturnDate], " +
            $"A.[RatedRating] AS [RatedRating], " +
            $"A.[TextualComment] AS [TextualComment], " +
            $"A.[NumberOfDays] AS [NumberOfDays], " +
            $"A.[RentalCost] AS [RentalCost], " +
            $"U.[ClientId] AS [ClientId], " +
            $"A.[CommentOfOwner] AS [CommentOfOwner], " +
            $"U.[UserName] AS [UserName] " +
            "FROM [Locations] AS [L] " +
            "INNER JOIN [Cars] AS [C] ON L.[LocationId] = C.[LocationId] " +
            "INNER JOIN [RentalCars] AS [A] ON C.[CarId] = A.[CarId] " +
            "INNER JOIN [Rentals] AS [R] ON A.[RentalId] = R.[RentalId] " +
            "INNER JOIN [Clients] AS [U] ON R.[ClientId] = U.[ClientId] " +
            "WHERE [L].[OwnerId] = @OwnerId ";

            var result = (await connection.QueryAsync<RentalDto>(sql, parameters)).AsList();
            return Result.Success(result);
        }
    }
}
