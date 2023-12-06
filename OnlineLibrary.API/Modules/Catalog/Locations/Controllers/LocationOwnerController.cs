using Microsoft.AspNetCore.Mvc;
using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.API.Modules.Catalog.Locations.Requests;
using OnlineRentCar.Modules.Catalog.Application.Locations.CreateLocation;

namespace OnlineRentCar.API.Modules.Catalog.Locations.Controllers
{
    [Route("api/location")]
    [ApiController]
    public class LocationOwnerController : ControllerBase
    {
        private readonly ICatalogModule _catalogModule;

        public LocationOwnerController(ICatalogModule catalogModule)
        {
            _catalogModule = catalogModule;
        }

        [HttpPost("create-location")]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationRequest request)
        {
            var location = await _catalogModule.ExecuteCommandAsync(new CreateLocationCommand(

                request.LocationName,
                request.ContactNumber,
                request.Email,
                request.OwnerUsername,
                request.Address
                ));
            return Ok(location);
        }
    }
}
