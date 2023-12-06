using Dapper;
using OnlineLibary.Modules.Catalog.Application.Configuration.Queries;
using OnlineRentCar.BuildingBlocks.Application.Data;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRentCar.Modules.Catalog.Application.Cars.GetAllCars
{
    public class GetAllCarsQueryHandler : IQueryHandler<GetAllCarsQuery, Result>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GetAllCarsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            string sql = "SELECT " +
                $"C.[CarId] AS [{nameof(CarDetailsDto.CarId)}], " +
                $"C.[Model] AS [{nameof(CarDetailsDto.Model)}], " +
                $"C.[Brand] AS [{nameof(CarDetailsDto.Brand)}], " +
                $"C.[Color] AS [{nameof(CarDetailsDto.Color)}], " +
                $"C.[Year] AS [{nameof(CarDetailsDto.Year)}], " +
                $"C.[VehicleType] AS [{nameof(CarDetailsDto.VehicleType)}], " +
                $"C.[DailyRate] AS [{nameof(CarDetailsDto.DailyRate)}], " +
                $"C.[IsAvailable] AS [{nameof(CarDetailsDto.IsAvailable)}], " +
                $"C.[AverageRating] AS [{nameof(CarDetailsDto.AverageRating)}], " +
                $"C.[NumberOfRatings] AS [{nameof(CarDetailsDto.NumberOfRatings)}], " +
                $"C.[NumberOfPassangers] AS [{nameof(CarDetailsDto.NumberOfPassangers)}], " +
                $"C.[TransmissionType] AS [{nameof(CarDetailsDto.TransmissionType)}], " +
                $"C.[NumberOfDoors] AS [{nameof(CarDetailsDto.NumberOfDoors)}], " +
                $"C.[Image] AS [{nameof(CarDetailsDto.Image)}], " +
                $"C.[FuelType] AS [{nameof(CarDto.FuelType)}], " +
            $"C.[Mileage] AS [{nameof(CarDto.Mileage)}], " +
                $"C.[LocationId] AS [{nameof(CarDetailsDto.LocationId)}], " +
                $"L.[LocationName] AS [{nameof(CarDetailsDto.LocationName)}] " +
                 "FROM [Cars] AS [C] " +
                 "JOIN [Locations] AS [L] ON C.[LocationId] = L.[LocationId] "+
                 "ORDER BY C.[CarId]";
            var result = (await connection.QueryAsync<CarDetailsDto>(sql)).AsList();
            return Result.Success(result);
        }
    }
}
