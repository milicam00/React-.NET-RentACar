using Dapper;
using OnlineLibary.Modules.Catalog.Application.Configuration.Queries;
using OnlineRentCar.BuildingBlocks.Application.Data;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscription;

namespace OnlineRentCar.Modules.Catalog.Application.Cars.GetCar
{
    public class GetCarQueryHandler : IQueryHandler<GetCarQuery, List<CarDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetCarQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<List<CarDto>> Handle(GetCarQuery query, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
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
            $"[NumberOfDoors] AS [{nameof(CarDto.NumberOfDoors)}], " +
            $"[FuelType] AS [{nameof(CarDto.FuelType)}], " +
            $"[Mileage] AS [{nameof(CarDto.Mileage)}], " +
            $"[Image] AS [{nameof(CarDto.Image)}] " +
            "FROM [Cars] AS [Cars] " +
            "WHERE 1 = 1 ";

            var parameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(query.Model))
            {
                sql += "AND [Model] LIKE '%' + @Model + '%' ";
                parameters.Add("Model", query.Model);
            }

            if (!string.IsNullOrEmpty(query.Brand))
            {
                sql += "AND [Brand] LIKE '%' +  @Brand + '%' ";
                parameters.Add("Brand", query.Brand);
            }

            if (query.Year.HasValue)
            {
                sql += "AND [Year] = @Year ";
                parameters.Add("Year", query.Year.Value);
            }

            if (!string.IsNullOrEmpty(query.FuelType))
            {
                sql += "AND [FuelType] LIKE '%' +  @FuelType + '%' ";
                parameters.Add("FuelType", query.FuelType);
            }

            if (!string.IsNullOrEmpty(query.VehicleType))
            {
                sql += "AND [VehicleType] LIKE '%' +  @VehicleType + '%' ";
                parameters.Add("VehicleType", query.VehicleType);
            }

            if (query.NumberOfPassangers.HasValue)
            {
                sql += "AND [NumberOfPassangers] = @NumberOfPassangers ";
                parameters.Add("NumberOfPassangers", query.NumberOfPassangers.Value);
            }

            if (!string.IsNullOrEmpty(query.TransmissionType))
            {
                sql += "AND [TransmissionType] LIKE '%' +  @TransmissionType + '%' ";
                parameters.Add("TransmissionType", query.TransmissionType);
            }

            if (query.NumberOfDoors.HasValue)
            {
                sql += "AND [NumberOfDoors] = @NumberOfDoors ";
                parameters.Add("NumberOfDoors", query.NumberOfDoors.Value);
            }


            sql += "AND [LocationId] IN (SELECT [LocationId] FROM [Locations] WHERE [IsActive] = 1)";

            return (await connection.QueryAsync<CarDto>(sql, parameters)).AsList();
        }

    }
}
