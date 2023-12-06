using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.Modules.Catalog.Application.Clients.BlockClient;
using OnlineRentCar.Modules.Catalog.Application.Clients.GetClients;
using OnlineRentCar.Modules.Catalog.Application.Clients.UnblockClient;
using OnlineRentCar.Modules.UserAccess.Application.BlockUser;
using OnlineRentCar.Modules.UserAccess.Application.Contracts;
using OnlineRentCar.Modules.UserAccess.Application.UnblockUser;

namespace OnlineRentCar.API.Modules.Catalog.Clients.Controllers
{
    [Route("Api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ICatalogModule _catalogModule;
        private readonly IUserAccessModule _userAccessModule;
        public ClientController(ICatalogModule catalogModule,IUserAccessModule userAccessModule ) 
        {
            _catalogModule = catalogModule;
            _userAccessModule = userAccessModule;
        }
        [Authorize(Roles = "Administrator")]
        [HttpPut("block-client/{username}")]
        public async Task<IActionResult> BlockUser([FromRoute] string username)
        {
            var firstTransaction = await _catalogModule.ExecuteCommandAsync(new BlockClientCommand(username)); 
            if (!firstTransaction.IsSuccess)
            {
                await _userAccessModule.ExecuteCommandAsync(new UnblockUserCommand(username));
            }

            var secondTransaction = await _userAccessModule.ExecuteCommandAsync(new BlockUserCommand(username));
            if (!secondTransaction.IsSuccess)
            {
                await _catalogModule.ExecuteCommandAsync(new UnblockClientCommand(username));
            }
            if (firstTransaction.IsSuccess && secondTransaction.IsSuccess)
            {
                return Ok("Successfully blocked client!");
            }
            else
            {
                return BadRequest("Blocking failed.");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("unblock-client/{username}")]
        public async Task<IActionResult> UnblockUser([FromRoute] string username)
        {
            var firstTransaction = await _catalogModule.ExecuteCommandAsync(new UnblockClientCommand(username));
            if (!firstTransaction.IsSuccess)
            {
                await _userAccessModule.ExecuteCommandAsync(new BlockUserCommand(username));
            }

            var secondTransaction = await _userAccessModule.ExecuteCommandAsync(new UnblockUserCommand(username));
            if (!secondTransaction.IsSuccess)
            {
                await _catalogModule.ExecuteCommandAsync(new BlockClientCommand(username));
            }
            if (firstTransaction.IsSuccess && secondTransaction.IsSuccess)
            {
                return Ok("Successfully unblocked client!");
            }
            else
            {
                return BadRequest("Unblocking failed.");
            }

        }

        [HttpGet("all-clients")]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _catalogModule.ExecuteQueryAsync(new GetClientsQuery());
            return Ok(clients);
        }
    }
}
