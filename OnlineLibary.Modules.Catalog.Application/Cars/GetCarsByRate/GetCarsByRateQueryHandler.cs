using Dapper;
using OnlineLibary.Modules.Catalog.Application.Configuration.Queries;
using OnlineRentCar.BuildingBlocks.Application.Data;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscription;

namespace OnlineRentCar.Modules.Catalog.Application.Cars.GetCarsByRate
{
    public class GetCarsByRateQueryHandler : IQueryHandler<GetCarsByRateQuery, List<CarDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GetCarsByRateQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<List<CarDto>> Handle(GetCarsByRateQuery query, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            int pageNumber = query.PageNumber;
            int pageSize = query.PageSize;

            string sql = "SELECT " +
           $"[CarId] AS [{nameof(CarDto.CarId)}], " +
           $"[Model] AS [{nameof(CarDto.Model)}], " +
           $"[Brand] AS [{nameof(CarDto.Brand)}], " +
           $"[Color] AS [{nameof(CarDto.Color)}], " +
           $"[Year] AS [{nameof(CarDto.Year)}], " +
           $"[VehicleType] AS [{nameof(CarDto.VehicleType)}], " +
           $"[DailyRate] AS [{nameof(CarDto.DailyRate)}], " +
           $"[IsAvailable] AS [{nameof(CarDto.IsAvailable)}], " +
           $"[AverageRating] AS [{nameof(CarDto.AverageRating)}], " +
           $"[NumberOfRatings] AS [{nameof(CarDto.NumberOfRatings)}] ," +
           $"[NumberOfPassangers] AS [{nameof(CarDto.NumberOfPassangers)}], " +
           $"[TransmissionType] AS [{nameof(CarDto.TransmissionType)}], " +
           $"[NumberOfDoors] AS [{nameof(CarDto.NumberOfDoors)}] " +
           "FROM [Cars] AS [Cars] " +
           "WHERE [AverageRating] >= @Rate AND [AverageRating] < (@Rate + 1) " +
               "ORDER BY [CarId] " +
               "OFFSET @Offset ROWS " +
               "FETCH NEXT @PageSize ROWS ONLY";

            var parameters = new
            {
                Rate = query.Rate,
                Offset = (pageNumber - 1) * pageSize,
                PageSize = pageSize
            };

            return (await connection.QueryAsync<CarDto>(sql, parameters)).AsList();
        }
    }
}
