using Microsoft.AspNetCore.Mvc;
using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.API.Modules.Catalog.Rentals.Requests;
using OnlineRentCar.Modules.Catalog.Application.Rentals.AddCommentOwner;
using OnlineRentCar.Modules.Catalog.Application.Rentals.CreateRental;
using OnlineRentCar.Modules.Catalog.Application.Rentals.RateCar;
using OnlineRentCar.Modules.Catalog.Application.Rentals.ReturnCar;

namespace OnlineRentCar.API.Modules.Catalog.Rentals.Controllers
{
    [Route("api/rentals")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly ICatalogModule _catalogModule;

        public RentalController(ICatalogModule catalogModule)
        {
            _catalogModule = catalogModule;
        }


        [HttpPost("rental-car")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        public async Task<IActionResult> RentalCar([FromBody] RentalRequest request)
        {
            
            var result = await _catalogModule.ExecuteCommandAsync(new CreateRentalCommand(
                    request.ClientId,
                    request.CarRentalRequests,
                    request.Date

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

        [HttpPost("rate-car/{carId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RateCar([FromRoute] Guid carId, RateRequest request)
        {

            var rate = await _catalogModule.ExecuteCommandAsync(new RateCarCommand(carId, request.Rate, request.Comment));
            if (rate.IsSuccess)
            {
                return Ok(rate);
            }
            else
            {
                return BadRequest(rate.ErrorMessage);
            }
        }

        [HttpPut("return-car/{rentalCarId}")]
        public async Task<IActionResult> ReturnCar([FromRoute] Guid rentalCarId)
        {
            var result = await _catalogModule.ExecuteCommandAsync(new ReturnCarCommand(rentalCarId));
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }

        [HttpPut("add-comment/{rentalId}/{comment}")]
        public async Task<IActionResult> AddComment( [FromRoute] string comment, [FromRoute] Guid rentalId)
        {
            var res = await _catalogModule.ExecuteCommandAsync(new AddCommentOwnerCommand (rentalId, comment));
            if (res.IsSuccess)
            {
                return Ok(res);
            }
            return BadRequest(res.ErrorMessage);    
        }
    }
}
