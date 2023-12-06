using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.API.Modules.Catalog.Cars.Requests;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Application.Cars.GetAllCar;
using OnlineRentCar.Modules.Catalog.Application.Cars.GetAllCars;
using OnlineRentCar.Modules.Catalog.Application.Cars.GetCar;
using OnlineRentCar.Modules.Catalog.Application.Cars.GetCarsByRate;
using OnlineRentCar.Modules.Catalog.Application.Cars.GetCarsOfLocation;
using OnlineRentCar.Modules.Catalog.Application.Locations.GetLocationsQuery;
using OnlineRentCar.Modules.Catalog.Application.Rentals.GetUserRentals;

namespace OnlineRentCar.API.Modules.Catalog.Cars.Controllers
{
    [Route("api/car")]
    [ApiController]
    public class CarClientController : ControllerBase
    {
        private readonly ICatalogModule _catalogModule;

        public CarClientController(ICatalogModule catalogModule)
        {
            _catalogModule = catalogModule;
        }

        //[Authorize(Roles = "Client")]
        [HttpGet("search-cars")]
        public async Task<IActionResult> SearchBooks([FromQuery] CarSearchRequest request)
        {
            var query = new GetCarQuery(
                request.Model,
                request.Brand,
                request.Year,
                request.FuelType,
                request.VehicleType,
                request.NumberOfPassangers,
                request.TransmissionType,
                request.NumberOfDoors);

            var cars = await _catalogModule.ExecuteQueryAsync(query);
            return Ok(cars);

        }


        [HttpGet("get-cars-of-location/{locationId}")]
        public async Task<IActionResult> GetCarsOfLibrary([FromRoute] Guid locationId)
        {

            var cars = await _catalogModule.ExecuteQueryAsync(new GetCarsOfLocationQuery(locationId));
            return Ok(cars);

        }

        [HttpGet("get-cars-by-rate/{rate}/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> CarsByRate([FromRoute] int rate, [FromRoute] int pageNumber, [FromRoute] int pageSize)
        {
            var cars = await _catalogModule.ExecuteQueryAsync(new GetCarsByRateQuery(rate, pageNumber, pageSize));
            return Ok(cars);
        }

        [HttpGet("get-all-cars")]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _catalogModule.ExecuteCommandAsync(new GetAllCarCommand());
            return Ok(cars);
        }


        [HttpGet("get-rental-cars/{username}")]
        public async Task<IActionResult> GetClientRentals([FromRoute] string username)
        {
            var cars = await _catalogModule.ExecuteQueryAsync(new GetUserRentalsQuery(username));
            return Ok(cars.Data);    
        }

        [HttpGet("get-all-car")]
        public async Task<IActionResult> GetAllCar()
        {
            var cars = await _catalogModule.ExecuteQueryAsync(new GetAllCarsQuery());
            return Ok(cars);
        }
    }
}
