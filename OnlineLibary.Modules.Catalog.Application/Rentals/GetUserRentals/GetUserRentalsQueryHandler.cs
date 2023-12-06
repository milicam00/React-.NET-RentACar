using Dapper;
using OnlineLibary.Modules.Catalog.Application.Configuration.Queries;
using OnlineRentCar.BuildingBlocks.Application.Data;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscriptions;
using OnlineRentCar.Modules.UserAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRentCar.Modules.Catalog.Application.Rentals.GetUserRentals
{
    public class GetUserRentalsQueryHandler : IQueryHandler<GetUserRentalsQuery, Result>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IClientRepository _clientRepository;
        public GetUserRentalsQueryHandler(IClientRepository clientRepository, ISqlConnectionFactory sqlConnectionFactory)
        {
            _clientRepository = clientRepository;
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result> Handle(GetUserRentalsQuery request, CancellationToken cancellationToken)
        {
            Client client = await _clientRepository.GetByUsername(request.Username);
            var connection = _sqlConnectionFactory.GetOpenConnection();
            var parameters = new { ClientId = client.ClientId };

            string sql = "SELECT " +
            $"C.[CarId] AS [{nameof(CarDto.CarId)}], " +
            $"C.[Model] AS [{nameof(CarDto.Model)}], " +
            $"C.[Brand] AS [{nameof(CarDto.Brand)}], " +
            $"C.[Color] AS [{nameof(CarDto.Color)}], " +
            $"C.[Year] AS [{nameof(CarDto.Year)}], " +
            $"C.[VehicleType] AS [{nameof(CarDto.VehicleType)}], " +
            $"C.[DailyRate] AS [{nameof(CarDto.DailyRate)}], " +
            $"C.[IsAvailable] AS [{nameof(CarDto.IsAvailable)}], " +
            $"C.[AverageRating] AS [{nameof(CarDto.AverageRating)}], " +
            $"C.[NumberOfRatings] AS [{nameof(CarDto.NumberOfRatings)}], " +
            $"C.[NumberOfPassangers] AS [{nameof(CarDto.NumberOfPassangers)}], " +
            $"C.[TransmissionType] AS [{nameof(CarDto.TransmissionType)}], " +
            $"C.[NumberOfDoors] AS [{nameof(CarDto.NumberOfDoors)}], " +
            $"C.[Image] AS [{nameof(CarDto.Image)}] " +
            "FROM [RentalCars] AS [RC] " +
            "LEFT JOIN [Cars] AS [C] ON RC.[CarId] = C.[CarId] " +
            "LEFT JOIN [Rentals] AS [R] ON RC.[RentalId] = R.[RentalId] " +
            "WHERE [R].[ClientId] = @ClientId";

            var result = (await connection.QueryAsync<CarDto>(sql, parameters)).AsList();

            return Result.Success(result);
        }
    }
}
