using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.Modules.Catalog.Application.Owners.BlockOwner;
using OnlineRentCar.Modules.Catalog.Application.Owners.GetOwners;
using OnlineRentCar.Modules.Catalog.Application.Owners.GetPreviousRentalsOwner;
using OnlineRentCar.Modules.Catalog.Application.Owners.UnblockOwner;
using OnlineRentCar.Modules.UserAccess.Application.BlockUser;
using OnlineRentCar.Modules.UserAccess.Application.Contracts;
using OnlineRentCar.Modules.UserAccess.Application.UnblockUser;

namespace OnlineRentCar.API.Modules.Catalog.Owners.Controllers
{
    [Route("api/owners")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly ICatalogModule _catalogModule;
        private readonly IUserAccessModule _userAccessModule;
        public OwnerController(ICatalogModule catalogModule, IUserAccessModule userAccessModule)
        {
            _catalogModule = catalogModule;
            _userAccessModule = userAccessModule;
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("block-owner/{username}")]
        public async Task<IActionResult> BlockUser([FromRoute] string username)
        {
            var firstTransaction = await _catalogModule.ExecuteCommandAsync(new BlockOwnerCommand(username));
            if (!firstTransaction.IsSuccess)
            {
                await _userAccessModule.ExecuteCommandAsync(new UnblockUserCommand(username));
            }

            var secondTransaction = await _userAccessModule.ExecuteCommandAsync(new BlockUserCommand(username));
            if (!secondTransaction.IsSuccess)
            {
                await _catalogModule.ExecuteCommandAsync(new UnblockOwnerCommand(username));
            }
            if (firstTransaction.IsSuccess && secondTransaction.IsSuccess)
            {
                return Ok("Successfully blocked owner!");
            }
            else
            {
                return BadRequest("Blocking failed.");
            }

        }

       [Authorize(Roles = "Administrator")]
        [HttpPut("unblock-owner/{username}")]
        public async Task<IActionResult> UnblockUser([FromRoute] string username)
        {
            var firstTransaction = await _catalogModule.ExecuteCommandAsync(new UnblockOwnerCommand(username));
            if (!firstTransaction.IsSuccess)
            {
                await _userAccessModule.ExecuteCommandAsync(new BlockUserCommand(username));
            }

            var secondTransaction = await _userAccessModule.ExecuteCommandAsync(new UnblockUserCommand(username));
            if (!secondTransaction.IsSuccess)
            {
                await _catalogModule.ExecuteCommandAsync(new BlockOwnerCommand(username));
            }
            if (firstTransaction.IsSuccess && secondTransaction.IsSuccess)
            {
                return Ok("Successfully unblocked owner!");
            }
            else
            {
                return BadRequest("Unblocking failed.");
            }

        }

        [HttpGet("get-owners")]
        public async Task<IActionResult> GetOwnersAsync()
        {
            var listOwners = await _catalogModule.ExecuteQueryAsync(new GetOwnersQuery());
            if(listOwners.IsSuccess)
            {
                return Ok(listOwners);
            }
            return BadRequest();
        }

        [HttpGet("rentals/{username}")]
        public async Task<IActionResult> GetRentals([FromRoute] string username)
        {
            var rentals = await _catalogModule.ExecuteQueryAsync(new GetPreviousRentalsOwnerQuery(username));
            if(rentals.IsSuccess)
            {
                return Ok(rentals);
            }
            return BadRequest();
        }
    }
}
