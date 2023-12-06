using Dapper;
using OnlineLibary.Modules.Catalog.Application.Configuration.Queries;
using OnlineRentCar.BuildingBlocks.Application.Data;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscription;

namespace OnlineRentCar.Modules.Catalog.Application.Cars.GetCarsOfLocation
{
    public class GetCarsOfLocationQueryHandler : IQueryHandler<GetCarsOfLocationQuery, List<CarDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GetCarsOfLocationQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public async Task<List<CarDto>> Handle(GetCarsOfLocationQuery request, CancellationToken cancellationToken)
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
               "WHERE [LocationId] = @locationId";
            var parameters = new { locationId = request.LocationId };
            return (await connection.QueryAsync<CarDto>(sql, parameters)).AsList();
        }
    }
}
