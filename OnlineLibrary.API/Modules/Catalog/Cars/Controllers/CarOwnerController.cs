using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.API.Modules.Catalog.Cars.Requests;
using OnlineRentCar.Modules.Catalog.Application.Cars.AddCar;
using OnlineRentCar.Modules.Catalog.Application.Cars.DeleteCar;
using OnlineRentCar.Modules.Catalog.Application.Cars.GetCarById;
using OnlineRentCar.Modules.Catalog.Application.Cars.GetCarsByRate;
using OnlineRentCar.Modules.Catalog.Application.Cars.SetCarAvailability;
using OnlineRentCar.Modules.Catalog.Application.Cars.UpdateCar;

namespace OnlineRentCar.API.Modules.Catalog.Cars.Controllers
{
    [Route("api/car")]
    [ApiController]
    public class CarOwnerController : ControllerBase
    {
        private readonly ICatalogModule _catalogModule;

        public CarOwnerController(ICatalogModule catalogModule)
        {
            _catalogModule = catalogModule;
        }

        //[Authorize(Roles = "Owner")]
        [HttpPost("add-car")]
        public async Task<IActionResult> AddCar([FromBody] AddCarRequest request)
        {
            var result = await _catalogModule.ExecuteCommandAsync(new AddCarCommand(
                request.Model,
                request.Brand,
                request.Color,
                request.Year,
                request.VehicleType,
                request.DailyRate,
                request.NumberOfPassangers,
                request.TransmissionType,
                request.NumberOfDoors,
                request.Image,
                request.Mileage,
                request.FuelType,
                request.LocationId
                ));

            if(result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }

        [Authorize(Roles = "Owner")]
        [HttpPut("update-car/{carId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EditCar([FromRoute] Guid carId, [FromBody] UpdateCarRequest request)
        {

            var result = await _catalogModule.ExecuteCommandAsync(new UpdateCarCommand(
            carId,
            request.Model,
            request.Brand,
            request.Color,
            request.Year,
            request.VehicleType,
            request.DailyRate,
            request.NumberOfPassangers,
            request.TransmissionType,
            request.NumberOfDoors,
            request.Image,
            request.Mileage,
            request.FuelType));
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }

        [HttpDelete("delete-car/{carId}")]
        public async Task<IActionResult> DeleteCar([FromRoute] Guid carId)
        {
            var result =await _catalogModule.ExecuteCommandAsync(new DeleteCarCommand(carId));
            if(result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage); 
            }
        }

        //[Authorize(Roles = "Owner")]
        [HttpPut("update-car-availability/{carId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAvailability([FromRoute] Guid carId, [FromBody] UpdateAvailabilityRequest request)
        {

            var result = await _catalogModule.ExecuteCommandAsync(new SetCarAvailabilityCommand(carId,request.IsAvailable));

            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("get-car/{carId}")]
        public async Task<IActionResult> CarsByRate([FromRoute] Guid carId)
        {
            var cars = await _catalogModule.ExecuteQueryAsync(new GetCarByIdQuery(carId));
            return Ok(cars);
        }
    }
}
