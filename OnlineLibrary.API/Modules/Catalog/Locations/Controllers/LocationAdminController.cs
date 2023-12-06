using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.API.Modules.Catalog.Locations.Requests;
using OnlineRentCar.Modules.Catalog.Application.Locations.DeactivateLocation;
using OnlineRentCar.Modules.Catalog.Application.Locations.GetAllLocations;
using OnlineRentCar.Modules.Catalog.Application.Locations.GetLocationsQuery;

namespace OnlineRentCar.API.Modules.Catalog.Locations.Controllers
{
    public class LocationAdminController : ControllerBase
    {
        private readonly ICatalogModule _catalogModule;
        public LocationAdminController(ICatalogModule catalogModule)
        {
            _catalogModule = catalogModule;
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPut("deactivate/{locationId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EditActivate([FromRoute] Guid locationId, UpdateLocationActivityRequest req)
        {

            var result = await _catalogModule.ExecuteCommandAsync(new DeactivateLocationCommand(locationId,req.IsActive));
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }

        }

      
        [HttpGet("get-locations/{ownerUsername}")]
        public async Task<IActionResult> GetLocations(string ownerUsername)
        {
            var locations = await _catalogModule.ExecuteQueryAsync(new GetLocationQuery(ownerUsername));
            return Ok(locations);
        }

        [HttpGet("get-all-locations")]
        public async Task<IActionResult> GetAllLocations()
        {
            var locations = await _catalogModule.ExecuteQueryAsync(new GetAllLocationsQuery());
            return Ok(locations);
        }



    }
}
