using Dapper;
using OnlineLibary.Modules.Catalog.Application.Configuration.Queries;
using OnlineRentCar.BuildingBlocks.Application.Data;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRentCar.Modules.Catalog.Application.Cars.GetCarById
{
    public class GetCarByIdQueryHandler : IQueryHandler<GetCarByIdQuery, CarDto>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GetCarByIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<CarDto> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            string sql = "SELECT " +
            $"[CarId] AS [{nameof(CarDto.CarId)}], " +
            $"[Model] AS [{nameof(CarDto.Model)}], " +
            $"[Brand] AS [{nameof(CarDto.Brand)}], " +
            $"[Color] AS [{nameof(CarDto.Color)}], " +
            $"[Image] AS [{nameof(CarDto.Image)}], " +
            $"[Year] AS [{nameof(CarDto.Year)}], " +
            $"[VehicleType] AS [{nameof(CarDto.VehicleType)}], " +
            $"[DailyRate] AS [{nameof(CarDto.DailyRate)}], " +
            $"[IsAvailable] AS [{nameof(CarDto.IsAvailable)}], " +
            $"[AverageRating] AS [{nameof(CarDto.AverageRating)}], " +
            $"[NumberOfRatings] AS [{nameof(CarDto.NumberOfRatings)}] ," +
            $"[NumberOfPassangers] AS [{nameof(CarDto.NumberOfPassangers)}], " +
            $"[TransmissionType] AS [{nameof(CarDto.TransmissionType)}], " +
            $"[Mileage] AS [{nameof(CarDto.Mileage)}], " +
            $"[FuelType] AS [{nameof(CarDto.FuelType)}], " +
            $"[NumberOfDoors] AS [{nameof(CarDto.NumberOfDoors)}] " +
            "FROM [Cars] AS [Cars] " +
               "WHERE [CarId] = @carId";
            var parameters = new { carId = request.CarId };
            return (await connection.QueryAsync<CarDto>(sql, parameters)).FirstOrDefault();
        }
    }
}
